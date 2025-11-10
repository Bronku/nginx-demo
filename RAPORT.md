# Konfiguracja reverse proxy na Linuxie z użyciem Nginx

## Cel

---

## 1. Stworzenie prostych aplikacji webowych

Jako że nie jest to główna część projektu, a jedynie jego element to aplikacje są bardzo proste

### Java

### .NET Core

Do tej demonstracji została użyta wersja dotnet 8.0.
Aplikacja składa się z dwóch części:

- dotnet.csproj zawierającej ustawienia projektu
- Program.cs zawiejącej kody który zostanie wykonany i uruchomi prosty serwer HTTP

### Docker

Obydwie aplikacje uruchomione są w dockerze, rozwiązanie to ma kilka zalet

- pozwala na łatwą reprodukcją środowiska na innej maszynie. Na przykład na innym komputerze, lub na maszynie wirtualnej w laboratorium
- ułatwia późniejszą konfigurację z Nginx (nie trzeba konfigurować oddzielnych adresów ani portów, dla kilku równoległych aplikacji)
- ułatwia uruchomienie całego środowiska (całość można uruchomić jedną komendą)

Każda aplikacja ma przygotowany plik `Dockerfile`, który jest wykorzystywany przez dockera do stworzenia kontera na podstawie kodu źródłowego.
Na potrzeby projektu plik `Dockerfile` jest mocno uproszczony i w zasadzie tylko uruchamia polecenie `dotnet run` dla c#, oraz .... dla java.

---

## 2. Stworzenie prostej sieci konterów z aplikacjami

Ponieważ do uruchomienia aplikacji używamy dockera, najprostszym sposobem na utworzenie wspólnej podsieci dla aplikacji i nginx jest użycie docker compose.

Docker compose jest narzędziem do definiowania i uruchamianiania wilokontenerowej aplikacji w dockerze.

- Normalnie w dockerze, uruchamia się kontener komendą `dotnet run`, ale gdy aplikacja potrzebuje kilku kontenerów (jak serwer, reverse proxy, ...) zarządzanie nimi staje się skomplikowane.
- Docker compose pozwala zdefiniować wszystkie kontenery i jak one oddziałają ze sobą w jednym pliku i uruchomienie wszystkiego jedną komendą

---

## 3. Stworzenie instancji reverse proxy

### Dodanie kontera

### Konfiguracja reverse proxy

---

## 4. Przekierowanie zapytań do odpowiednich aplikacji w zależności od nagłówków HTTP

### Konfiguracja reverse proxy

---

## 5. Load Balancing

### Utworzenie kopii kontenerów z aplikacjami

W ramach prezentacji działania reverse proxy kilka instancji tej samej aplikacja zostanie uruchomione na tej samej maszynie, w ramach podsieci dockera można o nich myśleć jako osobne maszyny wirtualne o osobnych adresach ip

### Konfiguracja reverse proxy

---

## 6. Rate Limiting

### Konfiguracja reverse proxy
