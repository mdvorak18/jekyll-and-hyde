# J&H: východisko pro plánování (shrnutí z relace 2026-10-16)

## Kontext
Hra "Jekyll & Hyde: A Most Dreadful Dream", UE 5.8.3 (C++), vývoj na Macu, Steam (Windows build až později). Autor píše scénář, design (JH_MASTER.yaml 6.8, TLD, kontrakty), skládá hudbu, dabing mají jeho lidé. Kód a technickou stavbu dělá Claude postupně. Pravidla: nic nepřepisovat bez souhlasu, zálohovat před úpravou, nevymýšlet TUNING čísla, minimální změny, česky.

## Stav designu
- Hotové: master 6.8, Narrative Flow, TLD pro S0, K1, S1, kontrakty (s0+k1, s1). K2 zatím jen textový nástin (TLD nevznikl). YAML není zamčený.
- Rozhodnutí o motivech (platí, zatím NEJSOU zapsaná v souborech): výsledky JEKYLL_RESOLVED (dříve FULFILLED) a HYDE_RESOLVED (dříve TWISTED), oba váha 100, MISSED = 0. BookQuality = 0.5*AuthoringQuality + 0.5*MotifClosure, hranice 60. LÁTKA vždy za Jekylla vypitím séra (cena: transformace a závislost přes události hyde_dependence, ne přímý zápis čísla). K1 BOLEST jen za Hyda.
- Otevřené: A) odměny za výsledky, B) kompenzace medikací (podle vzorců ne), C) kde v K2 Hyde po vypití séra vystoupí; K2_LATKA_INSTABILITY je neplatné.
- Připravený úkol: "MOTIVY OPRAVA JH" (fáze 1 audit bez zápisu, fáze 2 úpravy po schválení se zálohou).

## Technický stav (ověřeno)
- Unreal projekt `Jekyll and Hyde_A Most Dreadful Dream/JekyllAndHyde`: čistá Third Person šablona, žádné balíčky z Fab, minimální C++ modul (šablonový Character/GameMode/PlayerController), level Lvl_ThirdPerson (gray-box).
- MCP server v editoru běží (http://127.0.0.1:8000/mcp), 55 toolsetů. `.mcp.json` je jen v projektu Unrealu, v pracovní složce chybí, proto se nástroje do relace nenačítají. Zatím se volalo přímo přes HTTP (call_tool s toolset_name + tool_name bez prefixu).
- Ověřeno čtením: seznam toolsetů, aktuální level, kamera, log, screenshot viewportu (obraz vidět lze). Žádný zápisový nástroj se netestoval.

## Co umí MCP (z popisů nástrojů, nezkoušeno u zápisů)
- ANO: stavba levelu (spawn z třídy/assetu, transformace, tagy, komponenty, PCG), Sequencer (140 nástrojů: level sequence, kamery, střihy, klíčování, přehrání, link animací), Blueprinty (čtení/zápis grafu přes DSL, kompilace), DataTable (create, add_rows, import_file), UMG, gameplay tagy, PIE start/stop, log, automation testy, screenshoty.
- ČÁSTEČNĚ: práce s cizími Fab Blueprinty (netestováno, žádný v projektu), interakce (skládat od nuly přes Blueprint), DataAsset (jen create + set_properties), MetaHuman (žádný toolset), import assetů (meshe, textury, tabulky; audio nenalezeno), testování (neumím ovládat PIE).
- NE: Animation Blueprint/montage/state machine a retarget (žádný toolset), kompilace C++ přes MCP.
- C++ se píše na disku s Claudem, build jde z terminálu (Build.sh v UE 5.8 a Xcode jsou na Macu; build nezkoušen). Live Coding na Macu nejisté.

## Plán nákupů a technické záměry (z dokumentů v Info/)
Základ: Game Animation Sample (zdarma, lokomoce) -> Basic Melee Combat (Hyde) -> Dialogue Branch System -> Interaction System -> Modular Save System -> vlastní tenká story-state vrstva v C++ (žádný obří quest/RPG framework, žádný investigation framework). Doplňky: Ultra Dynamic Sky (počasí podle kapitoly), Wanted/Witness AI/Stealth AI kit (policie), viktoriánské prostředí a davy z Fab/CGTrader/Gumroad, zvířata, apothecary props, MetaHuman pro hlavní postavy. Pozn.: dokument s výběrem pochází z ChatGPT, tvrzení o Macu a UE 5.8 jsou neověřená.

## Animace (návrh řešení)
- Jedna kostra pro všechny hlavní postavy (MetaHuman). Jekyll a Hyde na stejné kostře = jeden AnimBP a jedna sada animací; transformace = výměna meshe.
- Základ: AnimBP a postava z Game Animation Sample, jen výměna meshe. Tím se obejde mezera v AnimBP přes MCP.
- Retarget: Epicův IK Retargeter (IK Rig zdroj/cíl, retargeter, hromadný retarget), ručně v editoru, jednou za typ kostry.
- Blender přes Claude: úprava nakoupených modelů (kosti, měřítko, FBX export, čištění). Skinning oděvů vyžaduje oko autora.
- Chybějící animace (pití séra, psaní, kašel, zatčení): Mixamo, ActorCore, případně ručně. Transformaci raději zakrýt střihem, mlhou a VFX.

## Reálnost zadání "autor jen píše a skládá"
Částečně. Claude zvládne: C++ jádro, story-state vrstvu, data z YAML (převodník -> JSON/DataTable), Blueprint logiku, napojení balíčků, rozmístění objektů, Sequencer scény, počasí podle kapitol, diagnostiku ze screenshotů.
Ručně autor: nákup a instalace z Fab, import z jiných tržišť (kontrola licencí), MetaHuman, retarget a nastavení animací, playtest (Claude hru neovládá a nepozná, jak se hraje), umělecký dohled nad levely, Windows build pro Steam.
Hlavní rizika: integrace 6–8 cizích systémů do jedné postavy, kompatibilita balíčků s Macem (zkontrolovat "Supported platforms" u každého), rozsah (17 kapitol, desítky systémů v masteru), pomalejší smyčka C++ mimo MCP, MetaHuman/MetaHuman Animator na Macu neověřeno.

## Doporučený postup
1. Dokončit/uzavřít design: zapsat rozhodnutí o motivech (audit fáze 1 -> schválení -> fáze 2), potom K2 TLD včetně bodů A–C.
2. Nenakupovat vše naráz. Vertikální řez S0 + K1: Game Animation Sample + Basic Melee Combat + Dialogue Branch + Interaction + Modular Save + jedna mapa a pár postav.
3. V řezu ověřit: načtení balíčků na Macu, čtení/úprava jejich Blueprintů přes MCP, retarget jedné animace na MetaHumana, build C++ z terminálu, první zápisové MCP operace (malé a reverzibilní).
4. Teprve podle výsledků nakoupit zbytek a vyřadit systémy z masteru, které se nevejdou.
5. Pro příští relace zkopírovat `.mcp.json` do pracovní složky (jen se souhlasem autora), aby se nástroje načítaly přímo.
