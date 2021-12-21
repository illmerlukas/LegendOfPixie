using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oberste Klasse für Spielobjekte meines PixelArt-Games.
/// Enthält allgemeine Funktionen, die für die meisten Szenenobjekte
/// potentiell nützlich sind.
/// </summary>
public class TheGameObject : MonoBehaviour
{
    /// <summary>
    ///  Größe eines PixelArt-Pixels in Unity-Einheiten.
    /// </summary>
    private static float pixelFrac = 1f / 16f; //16 = Pixels per Unit

    /// <summary>
    /// Runde auf PixelArt-Pixel
    /// </summary>
    /// <param name="f">Zahl, die gerundet werden soll.</param>
    /// <returns>f, eingerastet im PixelArt-Raster.</returns>
    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }

    /// <summary>
    /// Zeiger auf den Box-Collider für die Kollisionserkennung
    /// mittels isColliding, um die Suchfunktion einzusparen.
    /// </summary>
    protected BoxCollider2D boxCollider;

    /// <summary>
    /// Ergebnis-Zwischenspeicher für Kollisionserkennung
    /// mittels isColliding
    /// </summary>
    protected Collider2D[] colliders;

    /// <summary>
    /// Der Filter, der Kollisionsobjekte im Sinne von Hindernissen
    /// findet (Trigger werden ignoriert).
    /// </summary>
    protected ContactFilter2D obstacleFilter;

    /// <summary>
    /// Zeiger auf die Animator-Komponente, die die Sprite-Animation
    /// realisiert. Die Laufbewegung wird mit deisem Animator synchronisiert.
    /// </summary>
    protected Animator anim;

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
        anim = GetComponent<Animator>();
        obstacleFilter = new ContactFilter2D();
    }

    /// <summary>
    /// Anzahl der bei der letzten Kollisionsprüfung gefundenen
    /// Kollisionspartner (=Anzahl der Suchergebnisse in colliders[]).
    /// </summary>
    protected int numFound = 0;

    /// <summary>
    /// Prüft, ob eine Kollision zwischen dem BoxCollider2D dieses Spielobjekts
    /// und anderen 2D-Kollidern stattfindet.
    /// </summary>
    /// <returns><c>true</c> bei Kollision, <c>false</c> sonst.</returns>
    protected bool isColliding()
    {
        numFound = boxCollider.OverlapCollider(obstacleFilter, colliders);
        return numFound > 0;
    }

    /// <summary>
    /// Bewegung, die die Figur in diesem Frame vollziehen soll.
    /// 1 = nach rechts/oben, -1 = nach links/unten.
    /// </summary>
    public Vector3 change = new Vector3();

    // Update is called once per frame
    private void LateUpdate()
    {
        anim.SetFloat("change_x", change.x);
        anim.SetFloat("change_y", change.y);
        if (change.y <= -1f) anim.SetFloat("lookAt", 0f);
        else if (change.x <= -1f) anim.SetFloat("lookAt", 1f);
        else if (change.y >= 1f) anim.SetFloat("lookAt", 2f);
        else if (change.x >= 1f) anim.SetFloat("lookAt", 3f);

        // Anwenden der in change gesetzten Bewegung
        float step = roundToPixelGrid(1f * Time.deltaTime);
        Vector3 oldPosition = transform.position;
        transform.position += change * step;
        if (isColliding())
        {
            transform.position = oldPosition; //auf alte position springen (d.h. nicht in den collider reinlaufen)
            for (int i = 0; i < numFound; i++)
            {
                TouchableBlocker touchableBlocker = colliders[i].GetComponent<TouchableBlocker>();
                if (touchableBlocker != null) 
                    touchableBlocker.OnTouch();
            }
        }

        change = Vector3.zero;
    }

    /// <summary>
    /// Berechnet den genauen Mittelpunkt der Kachel in der
    /// sich die Figur gerade befindet. Kann verwendet werden,
    /// um die Figur in eine Kachel "einzurasten".
    /// </summary>
    /// <returns>Mittelpunkt der Kachel</returns>
    public Vector3 getFullTilePosition()
    {
        Vector3 position = transform.position;
        position.x = Mathf.FloorToInt(position.x);
        position.y = Mathf.CeilToInt(position.y);

        position.x += 0.5f;
        position.y -= 0.5f;

        return position;
    }

    /// <summary>
    /// Schiebt die Figur auf die um deltaX/deltaY Kacheln entfernte
    /// Nachbarkachel weiter.
    /// </summary>
    /// <param name="deltaX">Anzahl der Kacheln, um die die Figur horizontal verschoben wird.</param>
    /// <param name="deltaY">Anzahl der Kacheln, um die die Figur vertikal verschoben wird.</param>
    public void pushByTiles(float deltaX, float deltaY)
    {
        Vector3 tilePosition = getFullTilePosition();

        tilePosition.x += deltaX;
        tilePosition.y += deltaY;

        Vector3 oldPosition = getFullTilePosition();
        transform.position = tilePosition; // übersprung-endposition
        if (isColliding())
            transform.position = oldPosition;
        else
            StartCoroutine(animateMoveTowards(oldPosition, tilePosition));
    }

    /// <summary>
    /// Schiebt die Figur mit einer Animation von einer Position zu einer anderen.
    /// </summary>
    /// <param name="fromPosition">Start-Position</param>
    /// <param name="targetPosition">Ziel-Position</param>
    /// <returns></returns>
    private IEnumerator animateMoveTowards(Vector3 fromPosition, Vector3 targetPosition)
    {
        float duration = 0.3f;
        for (float t = 0f; t <= 1f; t += Time.deltaTime/duration)
        {
            transform.position = Vector3.Lerp(fromPosition, targetPosition, t);
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Drückt die Figur vom angegebenen Objekt wegwärts.
    /// </summary>
    /// <param name="deflector">Objekt von dem die Figur abprallt.</param>
    /// <param name="topLeftAnchor">Ist das Deflector-Objekt links oben ausgerichtet?</param>
    public void pushAwayFrom(MonoBehaviour deflector, bool topLeftAnchor)
    {
        Vector3 diff;

        if (topLeftAnchor) //= Ausrichtung links oben -> Mittelpunkt hier manuell berechnen
            diff = transform.position - (deflector.transform.position + new Vector3(0.5f, -0.5f, 0f));
        else //= Ausrichtung am Mittelpunkt
            diff = transform.position - deflector.transform.position;

        pushByTiles(diff.x, diff.y);
    }

    /// <summary>
    /// Lässt die Figur times mal blinken
    /// </summary>
    /// <param name="times">Anzahl wie oft die Figur blinken soll.</param>
    public void flicker(int times, Color color)
    {
        StartCoroutine(animateFlicker(times, color));
    }

    /// <summary>
    /// Animiert das Blinken, das mittels flicker() gestartet werden kann.
    /// </summary>
    /// <param name="times">Anzahl der Blink-Wiederholungen</param>
    /// <returns></returns>
    private IEnumerator animateFlicker(int times, Color color)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < times; i++)
        {
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
