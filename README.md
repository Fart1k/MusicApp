# MusicApp

Kirjeldus

MusicApp on .NET MAUI põhine multimeediarakendus, mis võimaldab kasutajal lisada, hallata ja esitada muusikafaile. Rakendus toetab SQLite andmebaasi, mitmekeelset kasutajaliidest ning heleda/tumeda teema vahetamist.

Funktsionaalsused

- Muusikapalade lisamine, kustutamine ja haldamine

- MP3 failide valimine seadmest (FilePicker)

- Muusika esitamine ja peatamine

- Andmete salvestamine SQLite andmebaasis

- Lokaliseerimine (eesti ja inglise keel)

- Tume ja hele teema (ThemeService + Preferences)

- Laulude järjestuse muutmine (Move Up / Move Down)

Tehnoloogiad

- .NET MAUI

- C#

- MVVM arhitektuur

- SQLite (sqlite-net-pcl)

- Plugin.Maui.Audio

- .NET Localization (.resx)

Projekti struktuur

- Models/ - andmemudelid (Song)

- ViewModels/ - rakenduse loogika

- Views/ - XAML kasutajaliides

- Services/ - Audio, DB, Settings, Theme, Localization

- Resources/Localization/ - tõlkefailid

