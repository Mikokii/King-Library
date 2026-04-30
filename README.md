# Katalog książek Stephena Kinga

## Cel projektu:

Celem zadania była implementacja aplikacji do obsługi katalogu książek Stephena Kinga. W ramach aplikacji można również dodawać własne książki. Aplikacja została napisana z użyciem .NET MAUI. Obsługuje zarówno systemy Android oraz iOS.

##  Wygląd aplikacji

Aplikacja prezentuje katalog książek posortowany po tytule alfabetycznie od A-Z. Każda książka ma reprezentujące ją zdjęcie, tytuł oraz rok wydania wraz z wydawcą na podglądzie w skrolowalnej sekcji. Każda sekcja posiada przycisk dodawania nowej książki. Ekran dodawania książki zawiera pola do wpisania metadanych o książce oraz miejsce do wklejenia linku dla obrazka. Każde pole posiada własną walidację. W aplikacji dostępny jest także podgląd danych szczegółowych o wybranej książce. 

## Dane

Dane o książkach są pobierane przy pierwszym uruchomieniu z pomocą REST API i są przechowyane lokalnie w bazie danych Realm.

## Architektura oraz wykonanie aplikacji

* MVVM oraz Clean Architecture
* Korzystanie z endpointu do poboru danych o książkach Stephena Kinga
* Realizacja bazy lokalnej w Realm
* Repostiory Pattern
* Dependecy Injection
* Czytelny podział na warstwy

## Zrzuty ekranu aplikacji
![img](https://github.com/user-attachments/assets/783cc7ad-7911-4f10-83df-655292a56204)
---
![img](https://github.com/user-attachments/assets/08c15c43-7d4f-47ce-89f3-1dbf861607cb)
---
![img](https://github.com/user-attachments/assets/1d4e293b-b9d8-4e67-8124-3684a93905c8)
