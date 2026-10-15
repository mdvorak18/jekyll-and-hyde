# Jekyll & Hyde: A Most Dreadful Dream — briefing pro Claude

Tento soubor je jen orientace. NEOBSAHUJE úkol. Nic neupravuj ani nezapisuj, dokud o to autor nepožádá.
Komunikace česky. Autor: Matouš Dvořák.

## Co je to za hru
Kompaktní third-person action RPG / psychologický horor s vyšetřováním, cíl 6-8 h (realisticky hustých 5-6 h).
Dvě reality: (1) Stevenson píše rukopis (domácí kapitoly S0-S8, pomalé, komorní, nemoc, léky, Fanny),
(2) Jekyll/Hyde ve stylizovaném viktoriánském Londýně (kapitoly K1-K8). Chronologie:
S0, K1, S1, K2, S2, K3, S3, K4, S4, K5, S5, K6, S6, K7, S7, K8, S8.
Core rule: Stevenson vytváří podmínky, témata a problémy; hráč rozhoduje, jak je vyřeší Jekyll nebo Hyde;
výsledky se stávají stavem rukopisu; stav rukopisu ovlivňuje Stevensona; ten nastavuje další kapitolu.
Konec: první rukopis vždy hoří (kvalitní spálí Fanny, nekvalitní Stevenson). Varianty: identita Hyde/Integrace x kvalita.

## Postavy
Jekyll (kontrola, příprava, společenská cesta: Reason, Society, Chemistry), Hyde (rychlost, brutalita, instinkt, mobilita:
Brutality, Instinct, Mobility), Stevenson, Fanny, Utterson, Lanyon, Poole, Carew, inspektor Newcomen, Rook, Crowther.
Hydeova závislost (HydeDependence) a transformace jsou jádro hry; látky/léky (Stevensonova strana) i sérum (Jekyllova strana)
mají lákat a stát. Závislost se ukazuje projevy (třes, zvuk, odraz), ne číslem.

## Kde jsme (stav práce)
- Autor je ve fázi level designu (TLD) po jednotlivých kapitolách. Po každé kapitole vzniká kumulativní kontrakt,
  aby bylo jasné, co vstupuje do dalšího levelu.
- Hotovo: JH_MASTER.yaml (verze 6.8, považován za téměř hotový), JH_Narrative Flow.yaml, TLD pro S0, K1, S1,
  kontrakty "1+2. s0+k1_kontrakt" a "3. s1_kontrakt". K2 a dál zatím ne (K2 je navržen textem, TLD nevznikl).
- Poté: psaní dialogů a drobností. Nesrovnalosti se čistí až na konci designu; YAML NENÍ zamčený a autor se vrací ke starším částem.
- Master je závazný; TLD a kontrakty ho musí dodržovat. Čísla označená TUNING jsou balanční výchozí hodnoty autora.
- Soubory bez přípony v "Technical level design" a "TLD výstup" jsou textové YAML.

## Rozhodnutí z poslední konzultace (platí, ale ještě NEJSOU zapsaná v souborech)
- Výsledky motivů: JEKYLL_RESOLVED (dříve FULFILLED) = motiv splnil Jekyll, HYDE_RESOLVED (dříve TWISTED) = splnil Hyde.
  Oba váha 100, MISSED = 0. Dřívější význam TWISTED (80) je zrušen. Odměny se liší podle toho, kdo motiv splnil.
- Kvalita rukopisu: BookQuality = 0.5*AuthoringQuality + 0.5*MotifClosure, hranice 60 (QUALITY/POOR).
  Stevensonův stav (bolest, únava, sedace, neklid...) dál ovlivňuje AuthoringQuality. Nízkou MotifClosure nejde
  dohnat medikací (AuthoringQuality + MotifClosure >= 120).
- Motiv LÁTKA vždy plní Jekyll vypitím séra; cena je transformace na Hyda a růst závislosti (přes události hyde_dependence).
- K1, motiv BOLEST: plní se jen za Hyda (incident s Rookem).
- Motivy fungují jako "quest log" bez konkrétních úkolů; main story motivy nevyžaduje (main_story_required: false).
- Otevřené: konkrétní odměny za výsledky, případná kompenzace nízké kvality, mapování LÁTKY v K2 (kde po vypití séra vystoupí Hyde).

## Technické záměry
- Unreal Engine 5.8.3, projekt s C++ v "Jekyll and Hyde_A Most Dreadful Dream/JekyllAndHyde" (JekyllAndHyde.uproject).
  Pluginy ModelContextProtocol a AllToolsets jsou zapnuté, .mcp.json odkazuje na http://127.0.0.1:8000/mcp (editor musí běžet
  se spuštěným serverem: ModelContextProtocol.StartServer). Server ověřen přes HTTP (2026-10-16): list_toolsets vrací 55 toolsetů. Jako nativní nástroje relace se načtou až po restartu nebo v nové relaci ve složce "Jekyll and Hyde (code)" (.mcp.json je i tam).
- Vývoj na Macu; Windows build (pro Steam) až později (cloudový/ jiný Windows stroj). Cíl vydání: Steam.
- Plán: YAML master -> převodník -> JSON / DataAssets / DataTables v Unrealu (Unreal YAML číst nemusí).
  Claude píše C++ jádro (JHStoryState, podmínky/efekty, save, serum/dependence, chapter manager, debug menu).
- Kupované/stažené základy (kandidáti, ověřit kompatibilitu s Mac a mezi sebou): Game Animation Sample (lokomoce),
  Basic Melee Combat System (Hyde), Dialogue Branch System, Interaction System, Modular Save System, Wanted/Witness AI/Stealth AI Kit,
  Ultra Dynamic Sky (počasí podle kapitoly), MetaHuman pro hlavní postavy (ověřit, co funguje na Macu).
- Nechtějí se obří RPG/quest frameworky: questy a inventář jsou vlastní tenká vrstva nad story-state.
- Cutscény primárně v Unreal Sequenceru; Higgsfield/Seedance a Blender jako doplněk (previz, stylizované vložky). Dabing nahrávají autorovi lidé;
  hudbu skládá autor.

## Rizika, na kterých se shoda
- Rozsah je velký (17 kapitol, desítky systémů v masteru: author packet mění varianty levelů, pursuit, pickpocket, shop state,
  recipe mastery, storage, economy). Některé systémy se pravděpodobně budou škrtat; rozhodnutí přijde při prototypu.
- Největší technické riziko: integrace více marketplace balíčků do jedné postavy (motion matching vs. boj vs. interakce).
  Doporučen brzký prototyp (jedna postava: pohyb, boj, dialog, save) před dalšími nákupy.
- Zpětná smyčka: Claude nevidí hru; kompilace a testování jde přes autora, pokud nefunguje MCP.

## Pravidla spolupráce
- Nic nepřepisuj ani nemaž bez souhlasu; před úpravou zálohuj; minimální změny; neformátuj soubory hromadně.
- Nevymýšlej TUNING čísla ani designová rozhodnutí; otevřené věci zapiš jako REQUIRES_DESIGN_RESOLUTION podle stávajících konvencí.
- Šetři kredity: neotvírej velké soubory celé, když stačí hlavičky nebo grep.

## Plán projektu

Závazný postup celého projektu je v souboru `PLAN_JH.md` (fáze, brány, role). Před zahájením práce si ho přečti a drž se ho. Kroky označené [L] dělá lokální relace (ty), kroky označené [Chat] cloudový chat na claude.ai, [M] dělá Matouš. Plán se nemění bez souhlasu Matouše. Živá verze je v cloudovém dokumentu, tento soubor je jeho kopie.
