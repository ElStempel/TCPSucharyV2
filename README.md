# TCPSucharyV2
Wykonano przez: Aleksander Stęplewski

## Wymagania funkcjonalne
- Łączenie z serwerem poprzez PuTTy. Serwer wysyła instrukcję do klienta i czeka na odpowiedź.
- Możliwe działania to wylosowanie i wysłanie suchara do klienta (komunikat "suchar"), dodanie nowego suchara do bazy przez klienta (komunikat "nowy"), lub rozłączenie (komunikat "quit").

## Wymagania pozafunkcjonalne
- Aplikacja serwera  jest dostarczona w postaci aplikacji konsolowej przeznaczonej na system Windows.
- W komunikacji klient-serwer wykorzystywany jest protokół komunikacyjny Raw.
- W ramach serwera jest implementowana obsługa rozłączającego się klienta.
- W ramach serwera nie jest implementowana informacja o wyłączeniu serwera przysłana do klienta.
- Serwer może utrzymać wiele połączeń, lecz nie jest to zalecane.
- Serwer po zakończeniu połączenia czeka na kolejne połączenia.
- Lista sucharów przechowywana jest w pliku tekstowym.
- Serwer wymaga .NET Framework w wersji 4.7.3 lub nowszej do działania.
- Testy odbywały się na platformie Windows oraz z użyciem terminala PuTTY.
