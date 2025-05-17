# CrazyFarmer
---Komanda---
Komanda X

---Autoriai---
Adomas Danilevičius
Jokūbas Stulpinas
Tomas Macijauskas
Domantas Barauskas

---Aprašymas---
Paprastas platformer tipo žaidimas dvimatėje erdvėje. Žaidimo tikslas - surikti kuo daugiau žaidimo taškų (score). Žaidime yra galimybė rinkti pinigus, už kuriuos galima nusipirkti kitokius žaidėjo modelius. 
Atidarius žaidimą naudotojas yra nukreipiamas į meniu, kuriame gali rinktis nustatymus, peržiūrėti kūrėjus ir rėmėjus, apsilankyti žaidimo parduotuvėje, keisti garso nustatymus ir išeiti iš žaidimo. Pasirinkus mygtuką 'Play' naudotojas yra užkraunamas į nesibaigiantį lygį, kuriame jis valdo žaidėją (farmerį). Žaidėją nuolatos puola įvairūs gyvūnai (meškos, vilkai, sakalai).
Žaidėjas turi 10 gyvybių, kurias gali pasipildyti atsirandančiais eleksyrais. Kiekvienas gyvūnas, palietęs žaidėją, nuima skirtingą kiekį gyvybių. Žaidėjas gali gintis nuo gyvūnų naudodamas savo šakę arba šaudydamas ugnies kamuolius iš savo šakės (žiūrėti žaidimo valdymą). 
Žemėpalyje galima rasti ir pinigų bei morkų. Pinigai yra kaupiami ir naudojami parduotuvėje, o morkos duoda taškų. Taškai, geriausias surinktas taškų skaičius, pinigų kiekis ir žaidime praleistas laikas yra kaupiamas lokaliai saugomame faile.

---Žaidimo valdymo vadovas---
(A arba <-) = žaidėjas juda į kairę pusę;
(D arba ->) = žaidėjas juda į dešinę pusę;
(Ilgas klavišas) = žaidėjas pašoka;
(Q) = keičiamas atakavimo rėžimas (šakė arba šaudymas);

---Testavimas---

| Veiksmas                                 | Norimas rezultatas                         | Gaunamas rezultatas                      |
|------------------------------------------|--------------------------------------------|------------------------------------------|
| Spaudžiamas A klavišas                   | Žaidėjas juda kairėn                       | Žaidėjas juda kairėn                     |
| Spaudžiamas D klavišas                   | Žaidėjas juda dešinėn                      | Žaidėjas juda dešinėn                    |
| Spaudžiamas ilgas klavišas               | Žaidėjas pašoka                            | Žaidėjas pašoka                          |
| Spaudžiamas ilgas klavišas dukart        | Žaidėjas pašoka ir dar kartą pašoka ore    | Žaidėjas pašoka ir dar kartą pašoka ore  |
| Spaudžiamas ilgas klavišas triskart      | Žaidėjas pašoka dukart (nuo žemės ir ore)  | Žaidėjas pašoka dukart (nuo žemės ir ore)|

