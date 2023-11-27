# Projekt na metodyki wytwarzania oprogramowania 

Celem projektu było utworzenie i konfiguracja pipeline'a **CI/CD** z wykorzystaniem **Github Actions** oraz integracja z **Azure DevOps** wykorzystując do tego REST API.

Napisany przeze mnie skrypt testuje poprawność wykonanych testów UI w **Selenium** dla mojej aplikacji webowej napisanej w **C#** i implementującej wzorzec **MVC**. W przypadku niepowodzenia procesu testowania, zostaje zgłaszany nowy workitem (Bug) w Azure DevOps.

## Aplikacja

Aplikacja została napisana w **.NET 7.0**, został wykorzystany wzorzec MVC (Model, View, Controller). Zostały zaimplementowane podstawowe metody CRUD: tworzenie, odczyt, edycja i usuwanie.
Aplikacja składa się na: stronę główną, domyślną stronę dot. prywatności, listę książek, formularz dodawania, edycji, usuwania i szczegółów książki. Zawartość bazy danych została wygenerowana z wykorzystaniem biblioteki **Bogus**.

![Główny wygląd aplikacji](./images/app-main.png)
![Lista książek](./images/app-library.png)



