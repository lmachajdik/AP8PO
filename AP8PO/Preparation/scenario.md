#1 Obecný scénář Vaší aplikace.
Nacitanie dat po spusteni z databaze / xml suborov (1).

- Uzivatel prida zamestnanca 
	- meno, telefon, email
	- zvoli pocet % uvazku 

- Uzivatel prida pocet studentov v odbore v rocniku
- Uzivatel prida predmety (skratka, nazov predmetu, rozsah, sposob ukoncenia )
- Uzivatel prida nazvy studijnych odborov
	- K tymto je potom mozne priradit predmety
		- predmet ma definovany pocet hodin
		- K jednotlivym predmetov priradi zamestnancov / vyucujucich 
			- pocet hodin nesmie prekracovat uvazok

- Aktualizacia poctu studentov
	- uzivatel moze zmenit pocet studentov v odbore 
	- riesit nezhody (2)

Ukladanie dat do databaze / xml suborov
		


#2 Otázky na které se chcete zeptat.
1) treba riesit vytvaranie projektov, alebo staci nacitat subory v relativnej adrese spusteneho programu, pripadne vybrat priecinok kde sa subory nachadzaju?
2) ako riesit nezhody v aktualizacii poctu studentov
   a) studentov je menej 
		- moze sa stat ze zamestnanec nebude mat priradeny predmet?
		- pripadne bude mat velku medzeru v hodinach vzhladom na jeho uvazok?

   b) studentov je viac 
		- v pripade maximalnej vytazenosti zamestnancov (vzhladom na ich uvazok) upozornit uzivatela alebo vykonat inu akciu?
3) ako riesit rocniky v odbore?
	
#3 Technologie, které chcete použít.
Desktop app - WPF - Windows Platform Foundation
Databaza - SQL - Entity Framework
