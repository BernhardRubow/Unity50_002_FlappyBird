#Flappy Bird Project
## Game Devs der Gesamtschule Salzkotten
##### Inhaltsverzeichnis
[Zielsetzung](#zielsetzung)   
[Gameplay](#gameplay)   
[Für dev's](#devstuff)   
[Copyright Infos](#copyright)   

<a name="zielsetzung">

### Zielsetzung
Entwicklung eines voll funktionsfähigen Clones des Spieles 'Flappy Bird' durch Entwicklung von 'Wegwerf'-Prototypen zur Erlangung von Domänenwissen. Diese erworbene Wissen wird dann in der Entwicklung des fertigen Spiels umgesetzt.

<a name="gameplay">

### Gameplay
Hier sind ein paar Bilder/Videos vom (hoffentlich) aktuellsten Stand des Spiels:   
![](./gameplay.gif "gameplay gif")

<a name="devstuff">

### Für dev's
#### Info: Das Event System benutzt int's als eine art ID. Hierfür verwenden wir die Funktion ``EventIdNorm.Hash(yourName, description)``
Hier ist eine Liste aller Events mit Person, Name und einer kurzen Beschreibung wann genau dieses Event getriggered wird   

| Person | Name             | Beschreibung (wann wird es getriggered?)        |
|--------|------------------|-------------------------------------------------|
| Fynn   | onScored         | wenn der spieler einen punkt erzielt            |
| Jan    | hitTube          | wenn der spieler stirbt                         |
| Fynn   | onStartButton    | wenn im hauptmenü auf start geklickt wird       |
| Fynn   | onSettingsButton | wenn im hauptmenü auf settings geklickt wird    |
| nvp    | movePressed      | wenn der vogel sich bewegt (nach oben)          |
   
PlayerPref liste: (case sensitive!! die keys sind/werden mit lowerCamelCase gespeichert)   

| Key          | Typ    | Beschreibung (was ist darin gespeichert?)         |
|--------------|--------|---------------------------------------------------|
| name         | string | Der Username (aus den settings)                   |
| soundVolume  | float  | Sound Effekt Lautstärke                           |
| musicVolume  | float  | Musik Lautstärke                                  |
| currentScore | int    | Die aktuelle Punktzahl vom Spieler                |
| firstStart   | int    | Ist das der erste spiel start? (0 = ja, 1 = nein) |

<a name="copyright">

### Copyright Infos
Zur Zeit benuzten wir Assets von den folgenden Quellen bzw. Personen:
- myinstants.com
- Calvin Rien