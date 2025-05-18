# CrazyFarmer
### Komanda
* Komanda X

### Autoriai

* [@bebras404] - Adomas Danilevičius
* [@jacobobos] - Jokūbas Stulpinas
* [@Tomzaza-joint] - Tomas Macijauskas
* [@Damke24] - Domantas Barauskas

### Aprašymas

Paprastas platformer tipo žaidimas dvimatėje erdvėje. Žaidimo tikslas - surinkti kuo daugiau žaidimo taškų (score). Žaidime yra galimybė rinkti pinigus, už kuriuos galima nusipirkti kitokius žaidėjo modelius. 
Atidarius žaidimą naudotojas yra nukreipiamas į pradinį meniu, kuriame gali rinktis nustatymus, peržiūrėti kūrėjus ir rėmėjus, apsilankyti žaidimo parduotuvėje, keisti garso nustatymus ir išeiti iš žaidimo. Pasirinkus mygtuką 'Play' naudotojas yra užkraunamas į nesibaigiantį lygį, kuriame jis valdo žaidėją (farmerį). Žaidėją nuolatos puola įvairūs priešai, šiuo atvėju, gyvūnai (meškos, vilkai, sakalai).
Žaidėjas turi 10 gyvybių, kurias gali pasipildyti skirtingose vietose lygyje atsirandančiais eleksyrais. Kiekvienas gyvūnas, palietęs žaidėją, nuima skirtingą kiekį gyvybių. Žaidėjas gali gintis nuo gyvūnų naudodamas savo šakę arba šaudydamas ugnies kamuolius iš savo šakės (žiūrėti žaidimo valdymą). 
Žemėpalyje galima rasti ne tik gydančių eliksyrų ar stipresnias galias suteikančių daiktų, bet ir pinigų bei morkų. Pinigai yra kaupiami ir gali bųti panaudoti parduotuvėje, o morkos surinktos duoda taškų. Taškai, geriausias surinktas taškų skaičius, pinigų kiekis ir žaidime praleistas laikas yra kaupiamas lokaliai saugomame faile.

### Žaidimo valdymo vadovas
* (A arba <-) = žaidėjas juda į kairę pusę;
* (D arba ->) = žaidėjas juda į dešinę pusę;
* (Ilgas klavišas) = žaidėjas pašoka;
* (Q) = keičiamas atakavimo rėžimas (šakė arba šaudymas);

### Testavimas

| Veiksmas                                 | Norimas rezultatas                         | Gaunamas rezultatas                      |
|------------------------------------------|--------------------------------------------|------------------------------------------|
| Spaudžiamas A klavišas                   | Žaidėjas juda kairėn                       | Žaidėjas juda kairėn                     |
| Spaudžiamas D klavišas                   | Žaidėjas juda dešinėn                      | Žaidėjas juda dešinėn                    |
| Spaudžiamas ilgas klavišas               | Žaidėjas pašoka                            | Žaidėjas pašoka                          |
| Spaudžiamas ilgas klavišas dukart        | Žaidėjas pašoka ir dar kartą pašoka ore    | Žaidėjas pašoka ir dar kartą pašoka ore  |
| Spaudžiamas ilgas klavišas triskart      | Žaidėjas pašoka dukart (nuo žemės ir ore)  | Žaidėjas pašoka dukart (nuo žemės ir ore)|
| Spaudžiamas "Play" mygtukas              | Pasijungia žaidimas                        | Pasijungia žaidimas                      |
| Spaudžiamas "Play" mygtukas dukart       | Pasijungia žaidimas                        | Pasijungia žaidimas                      |
| Spaudžiamas "Play" mygtukas triskart     | Pasijungia žaidimas                        | Pasijungia žaidimas                      |
| Spaudžiamas "Options" mygtukas           | Pasijungia nustatymai                      | Pasijungia nustatymai                    |
| Spaudžiamas "Options" mygtukas dukart    | Pasijungia nustatymai                      | Pasijungia nustatymai                    |
| Spaudžiamas "Options" mygtukas triskart  | Pasijungia nustatymai                      | Pasijungia nustatymai                    |
| Spaudžiamas "Exit" mygtukas              | Žaidimas išsijungia                        | Žaidimas išsijungia                      |
| Spaudžiamas "Exit" mygtukas dukart       | Žaidimas išsijungia                        | Žaidimas išsijungia                      |
| Spaudžiamas "Exit" mygtukas triskart     | Žaidimas išsijungia                        | Žaidimas išsijungia                      |
| Spaudžiamas "Shop" mygtukas              | Pasijungia parduotuvė                      | Pasijungia parduotuvė                    |
| Spaudžiamas "Shop" mygtukas dukart       | Pasijungia parduotuvė                      | Pasijungia parduotuvė                    |
| Spaudžiamas "Shop" mygtukas triskart     | Pasijungia parduotuvė                      | Pasijungia parduotuvė                    |
| Spaudžiamas "Credits" mygtukas           | Pasijungia kreditai                        | Pasijungia kreditai                      |
| Spaudžiamas "Credits" mygtukas dukart    | Pasijungia kreditai                        | Pasijungia kreditai                      |
| Spaudžiamas "Credits" mygtukas triskart  | Pasijungia kreditai                        | Pasijungia kreditai                      |

