# CrazyFarmer
### Komanda
* Komanda X

### Autoriai

* [@bebras404] - Adomas Danilevičius
* [@jacobobos] - Jokūbas Stulpinas
* [@Tomzaza-joint] - Tomas Macijauskas
* [@Damke24] - Domantas Barauskas

### Aprašymas

Paprastas "platformer" tipo žaidimas dvimatėje erdvėje (2D). Žaidimo tikslas - surinkti kuo daugiau žaidimo taškų (score). Žaidime yra galimybė rinkti pinigus, už kuriuos galima nusipirkti kitokius žaidėjo patobulinimus. 
Atidarius žaidimą naudotojas yra nukreipiamas į pradinį meniu, kuriame gali rinktis nustatymus, peržiūrėti kūrėjus ir rėmėjus, apsilankyti žaidimo parduotuvėje, keisti garso nustatymus ir išeiti iš žaidimo. Pasirinkus mygtuką 'Play' naudotojas yra užkraunamas į nesibaigiantį lygį, kuriame jis valdo žaidėją (farmerį). Žaidėją nuolatos puola įvairūs priešai, šiuo atvėju, gyvūnai (meškos, vilkai, sakalai).
Žaidėjas turi 10 gyvybių, kurias gali pasipildyti skirtingose vietose lygyje atsirandančiais eleksyrais. Kiekvienas gyvūnas, palietęs žaidėją, nuima skirtingą kiekį gyvybių. Žaidėjas gali gintis nuo gyvūnų naudodamas savo šakę arba šaudydamas ugnies kamuolius iš savo šakės (žiūrėti žaidimo valdymą). 
Žemėpalyje galima rasti ne tik gydančių eliksyrų ar stipresnias galias suteikančių daiktų, bet ir pinigų bei morkų. Pinigai yra kaupiami ir gali būti panaudoti parduotuvėje, o morkos surinktos duoda taškų. Taškai, geriausias surinktas taškų skaičius, pinigų kiekis ir žaidime praleistas laikas yra kaupiamas lokaliai saugomame faile.

### Žaidimo valdymo vadovas
* (A arba <-) = žaidėjas juda į kairę pusę;
* (D arba ->) = žaidėjas juda į dešinę pusę;
* (Ilgas klavišas) = žaidėjas pašoka;
* (Q) - suteikia žaidėjui nemirtingumą;
* (E) - suteikia žaidėjui galimybę šaudyti;

### Testavimas

| Veiksmas                                     | Norimas rezultatas                         | Gaunamas rezultatas                      |
|----------------------------------------------|--------------------------------------------|------------------------------------------|
| Spaudžiamas A klavišas                       | Žaidėjas juda kairėn                       | Žaidėjas juda kairėn                     |
| Spaudžiamas D klavišas                       | Žaidėjas juda dešinėn                      | Žaidėjas juda dešinėn                    |
| Spaudžiamas ilgas klavišas                   | Žaidėjas pašoka                            | Žaidėjas pašoka                          |
| Spaudžiamas ilgas klavišas dukart            | Žaidėjas pašoka ir dar kartą pašoka ore    | Žaidėjas pašoka ir dar kartą pašoka ore  |
| Spaudžiamas ilgas klavišas triskart          | Žaidėjas pašoka dukart (nuo žemės ir ore)  | Žaidėjas pašoka dukart (nuo žemės ir ore)|
| Spaudžiamas "Play" mygtukas                  | Pasijungia žaidimas                        | Pasijungia žaidimas                      |
| Spaudžiamas "Play" mygtukas dukart           | Pasijungia žaidimas                        | Pasijungia žaidimas                      |
| Spaudžiamas "Play" mygtukas triskart          | Pasijungia žaidimas                        | Pasijungia žaidimas                      |
| Spaudžiamas "Options" mygtukas                | Pasijungia nustatymai                      | Pasijungia nustatymai                    |
| Spaudžiamas "Options" mygtukas dukart         | Pasijungia nustatymai                      | Pasijungia nustatymai                    |
| Spaudžiamas "Options" mygtukas triskart       | Pasijungia nustatymai                      | Pasijungia nustatymai                    |
| Spaudžiamas "Exit" mygtukas                   | Žaidimas išsijungia                        | Žaidimas išsijungia                      |
| Spaudžiamas "Exit" mygtukas dukart            | Žaidimas išsijungia                        | Žaidimas išsijungia                      |
| Spaudžiamas "Exit" mygtukas triskart          | Žaidimas išsijungia                        | Žaidimas išsijungia                      |
| Spaudžiamas "Shop" mygtukas                   | Pasijungia parduotuvė                      | Pasijungia parduotuvė                    |
| Spaudžiamas "Shop" mygtukas dukart            | Pasijungia parduotuvė                      | Pasijungia parduotuvė                    |
| Spaudžiamas "Shop" mygtukas triskart          | Pasijungia parduotuvė                      | Pasijungia parduotuvė                    |
| Spaudžiamas "Credits" mygtukas                | Pasijungia kreditai                        | Pasijungia kreditai                      |
| Spaudžiamas "Credits" mygtukas dukart         | Pasijungia kreditai                        | Pasijungia kreditai                      |
| Spaudžiamas "Credits" mygtukas triskart       | Pasijungia kreditai                        | Pasijungia kreditai                      |
| Spaudžiamas "Restart" mygtukas                | Pasijungia žaidimas iš naujo               | Pasijungia žaidimas iš naujo             |
| Spaudžiamas "Restart" mygtukas dukart         | Pasijungia žaidimas iš naujo               | Pasijungia žaidimas iš naujo             |
| Spaudžiamas "Restart" mygtukas triskart       | Pasijungia žaidimas iš naujo               | Pasijungia žaidimas iš naujo             |
| Spaudžiamas "Back to menu" mygtukas           | Grižtama į pradinį žaidimo menu            | Grižtama į pradinį žaidimo meniu         |
| Spaudžiamas "Back to menu" mygtukas dukart    | Grižtama į pradinį žaidimo menu            | Grižtama į pradinį žaidimo meniu         |
| Spaudžiamas "Back to menu" mygtukas triskart  | Grižtama į pradinį žaidimo menu            | Grižtama į pradinį žaidimo meniu         |
| Žaidėjas paima pinigėlį                       | 1 pridedamas prie pinigų bendros sumos     | 1 pridedamas prie pinigų bendros sumos   |
| Žaidėjas paima eleksyrą                       | Žaidėjas yra pagydomas                     | Žaidėjas yra pagydomas                   |
| Žaidėjas paima morką                          | Žaidėjui yra suteikiami papildomi taškai   | Žaidėjui yra suteikiami papildomi taškai |
| Žaidėjas iškrenta iš žemėlapio                | Žaidėjas miršta                            | Žaidėjas miršta                          |
|Žaidėjas paliečia priešą (erelį, lokį ar vilką)| Žaidėjui nuimamos gyvybės                  | Žaidėjui nuimamos gyvybės                | 


[@bebras404]: <https://github.com/bebras404>
[@jacobobos]: <https://github.com/jacobobos>
[@Tomzaza-joint]: <https://github.com/Tomzaza-joint>
[@Damke24]: <https://github.com/Damke24>



