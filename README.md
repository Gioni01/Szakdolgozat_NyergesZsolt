Ezt a dolgozatot a Járműfedélzeti Rendszerek 2. tárgyhoz készítem, az oktatás ke-
retében megvalósított féléves beadandó programom dokumentációját tartalmazza. Ez
alapján meg kellett valósítanom egy járműdinamikai szimulátort, amely magába foglalja
a jármű mozgását a kinematikai modellje alapján. Mindemellett felhasználásra került a
dinamikai alapelvek, matematikai modellek és még az irányítás megvalósítása is a külön-
böző hálózatokon keresztül. A feladatom során külön figyelmet fordítottam az autóipari
szabványokra, mely magába foglalja az általam használt CAN és UART kommunikációs
prototkollt. Ezeknek a segítségével lehetőságem nyílt a valós idejű adatcsere megvalósí-
tására és a járműmodell hatékony irényítására.
A dolgozat elején ismertetem az általam felhasznált járműipari kommunikációs háló-
zatokatokat, beleértve a CAN és UART hálózatokat, melyek elősegítették a projekt adat-
küldés és fogadási lehetőségeit. Ezek mellett még említést teszek a LIN hálózatról, annak
előnyeiről és a CAN hálózatba való integrációjáról. Biztosítani kellett még a számítógép
és mikrokontroller közötti adatkapcsolatot, melyre az UART hálózat került kiválasztásra.
Mindezek együttese lehetővé tette a jármű valós idejű nyomonkövetését és finomhangolá-
sát. Ezek után említésre került a járműmodellezési alapok, ahol betekintést biztosítotok
a kereszt- és hosszirányú modellalkotásba. Mind a dinamikus, mind a kinematikus modell
bemutatásra került, és a kerékpár modell alapjait is megismertetem. A modell kidolgozása
során az egyszerűségre és pontosságra törekedtem, hogy a legpontosabb képet kaphassuk a
jármű mozgásáról. A futásidő optimalizálásra került és bíztam benne, hogy mindeközben
a szimuláció hiteles marad. A CAN-ből érkező adatok feldolgozását egy mikrokontroller
biztosította, mely a fent említett modellek alapján kiszámításra került a gépjármű pontos
lokációja. A mikrokontrollerek fejlődése, és működési elvét is ismeretetem. Mindemellett
elengedethetetlen volt egy debugger használata, mely a könnyű hibakeresést és diagnosz-
tizálást tette lehetővé. Az írt kódnak a vizuális megjelenítésére egy C# nyelven íródott
Windows Forms Application került létrehozásra, mely egy grafikus felületet biztosított,
ami a jármű pozíciójának szemügyre vételezésére alkalmas. Itt az autó mellett láthattuk a
pontos x és y helyét, a test elfordulási szögének értékét. Különböző gombok tették lehető-
vé az adott pillanatban a kényelmesebb megjelenítés érdekében, néhány könnyítő vizuális
segítséget. Az irányítás megvalósítása alatt alkalmazott algoritmusok és visszacsatolási
logikák biztosították a szimuláció hitelességét. Különösképp figyelmet kellett fordítani a
protokollok szinkronizálása, időzítők kezelése vagy a vizualizáció realitásának fenntartá-
sa. Ennek kifejlesztése érdekében több megoldási módszerek alapján kiválasztottam a
legmegfelelőbbet.
Az elkészült projekt számos alkalmazási lehetőséget tartogat magában, mint például
kutatás céljából felhasználható vagy ipari környezetben alkalmazható a paraméterek vál-
toztatásával egy új modell kifejlesztésére akár. Számos továbbfejlesztési lehetőség még a
jövőben lehetőséget tartogat, mint a valós környezet és paramatérek alkalmazása vagy a
mesterséges intelligencia implementálása
