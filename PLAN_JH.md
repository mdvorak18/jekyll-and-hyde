# J&H – Master plán projektu

Stav k 2026-10-16. Toto je kopie pro lokální Claude Code. Živá verze, kterou udržuje cloudový chat, je v dokumentu "J&H – Master plán projektu" na claude.ai. Při rozporu platí živá verze. Po každé dokončené fázi se tento soubor přepíše aktuální kopií (jen se souhlasem Matouše).

## Zásady a role

Cíl: hratelná, vizuálně i zvukově silná hra na Steam, bez jakéhokoli výdaje, dokud to nebude nutné. První výdaj smí přijít až po Bráně 1 (konec Fáze 3).

1. Nejdřív zdarma a vlastní, kupujeme jen to, co vertikální řez prokáže jako nezbytné.
2. Před každou úpravou záloha, nic se nepřepisuje bez souhlasu, TUNING čísla se nevymýšlejí.
3. Jediný zdroj pravdy o designu je `JH_MASTER.yaml`. Rozhodnutí z chatu se zapisují do něj, ne jen do konverzace.
4. Malé reverzibilní kroky. Po každém se ověří výsledek (log, screenshot viewportu, test).
5. Tento dokument se po každé fázi aktualizuje: co je hotovo, co se změnilo, co se škrtlo.

| Oblast | Claude ([L] lokální, [Chat] rešerše a design) | Matouš |
| --- | --- | --- |
| Design, YAML, TLD, kontrakty | píše, kontroluje shodu, zapisuje změny po souhlasu | vymýšlí děj a pravidla, schvaluje |
| C++ a data | píše kód, převodník YAML na JSON/DataTable, build z terminálu | spouští a restartuje editor, hlásí chyby |
| Level, Blueprinty, Sequencer | staví přes MCP, kontroluje screenshoty | umělecký dohled, hodnotí vzhled |
| Animace | připravuje kostry a modely v Blenderu | IK Retargeter a nastavení v editoru |
| Postavy (MetaHuman) | připraví seznam a požadavky | vytváří ručně v editoru |
| Assety | hledá, kontroluje licence a podporu Macu | stahuje a instaluje z Fab a jiných tržišť |
| Hudba, dabing | připraví seznam replik, importní postup, napojení | skládá hudbu, dodává nahrávky od svých lidí |
| Playtest | čte log, spouští automatické testy | hraje a hodnotí, jak se hra hraje |
| Build a Steam | připraví kontrolní seznam | zajistí Windows počítač, Steamworks účet |

### Který Claude co dělá

V plánu značí [L] lokální Claude Code (aplikace, záložka Code), [Chat] tento cloudový chat na claude.ai a [M] vás. Jsou to dvě různé relace a nevidí si do hlavy.

- **[L] Lokální Claude Code** (aplikace, záložka Code, složka `Jekyll and Hyde (code)`): vše, co se týká editoru a Macu. MCP (level, Blueprinty, Sequencer, screenshoty), C++ a build, Blender, Git, automatické testy, úpravy YAML a TLD v souborech.
- **[Chat] Cloudový chat**: plánování, diskuse o designu, rozhodnutí, rešerše na webu (licence, ceny, podpora Macu), psaní promptů a dokumentů, udržování plánu. Nevidí běžící editor ani MCP.
- Rozhodnutí z chatu se zapíše do `JH_MASTER.yaml` nebo `CLAUDE.md`, jinak o něm lokální relace neví. Po práci v lokální relaci její shrnutí vložit do chatu.
- Kroky označené [L] dělá lokální relace, kroky označené [Chat] tento chat (rešerše, licence, ceny, diskuse o designu).

## Fáze 0: Příprava zdarma

Cíl: ověřit, že nejdůležitější technické předpoklady skutečně fungují, než na nich postavíme cokoli dalšího. [M] = Matouš, [L] = lokální Claude Code, [Chat] = tento cloudový chat.

- [x] [M] Souhlas s kopírováním `.mcp.json` do složky `Jekyll and Hyde (code)`, aby se nástroje načítaly přímo.
- [x] [L] Zkopírovat `.mcp.json`, ověřit, že se nástroje načtou v nové relaci.
- [ ] [M] Zapnout zálohování: Time Machine plus Git repozitář. Podrobný postup je pod seznamem.
- [ ] [L] Založit `.gitignore` pro Unreal (Binaries, Intermediate, Saved, DerivedDataCache) a první commit.
- [ ] [L] Zápisový test MCP v oddělené testovací mapě: vytvořit pár actorů, jednu Level Sequence s kamerou, jednoduchý Blueprint, udělat screenshot, pak vše uklidit.
- [ ] [L] Ověřit build C++ z terminálu (Build.sh) a přesný příkaz zapsat do `CLAUDE.md`.
- [ ] [M] Zkusit v editoru Live Coding na Macu a oznámit výsledek. Pokud nefunguje, po každém buildu restart editoru.
- [ ] [L] Zapsat, co funguje a co ne, do `CLAUDE.md` a do tohoto dokumentu.

### Zálohování krok za krokem

Žádný konektor ani účet na GitHubu není potřeba. Git je lokální nástroj, který Claude spustí ve složce projektu. Záloha na GitHub je jen volitelný bonus.

1. Time Machine (záloha celého Macu včetně velkého Contentu):
    - Pořiďte externí disk, ideálně 1 TB nebo víc. Projekt s Fab obsahem může mít desítky GB.
    - Připojte disk k Macu.
    - Otevřete Nastavení systému, Obecné, Time Machine, Přidat zálohovací disk, vyberte disk a zapněte automatické zálohování.
    - Spusťte první zálohu a nechte ji doběhnout. Další pak běží sama, když je disk připojený.
2. Git (historie změn kódu, YAML a TLD):
    - Git je na Macu už s Xcode, nic se neinstaluje.
    - Claude ve složce `Jekyll and Hyde (code)` spustí `git init`, založí `.gitignore` pro Unreal a udělá první commit. Vy jen odsouhlasíte.
    - Velké binární soubory (Content, .uasset) do Gitu nedávejte, pokrývá je Time Machine. Git LFS řešte, až bude potřeba.
3. Záloha na GitHub (volitelné, jen pro kód, data a design):
    - Vytvořte si účet na GitHubu zdarma a prázdný soukromý repozitář.
    - Jednou se z lokální relace přihlaste (Claude vám dá přesný příkaz) a pak stačí `git push`.
    - Konektor pro GitHub v aplikaci k tomu není potřeba.
4. Pravidlo: commit po každém dokončeném kroku plánu a Time Machine vždy před větší změnou.

**Brána 0:** zápis přes MCP funguje, C++ se buildne a záloha běží. Pokud zápis nefunguje, vracíme se k plánu B: Claude připravuje data a kód na disku a level skládáte v editoru vy podle jeho návodu.

## Fáze 1: Uzavření designu (běží souběžně s Fází 0 a 2)

Technika nemusí čekat na K2, protože vertikální řez používá jen S0 a K1, které mají TLD hotové. Motivy je ale potřeba opravit dřív, než se z nich začne generovat kód.

- [ ] [L] Audit motivů (fáze 1 úlohy "MOTIVY OPRAVA JH", jen čtení): seznam všech míst s FULFILLED a TWISTED v masteru, TLD a kontraktech.
- [ ] [M] Schválit audit.
- [ ] [L] Záloha, pak úpravy: JEKYLL_RESOLVED a HYDE_RESOLVED (váha 100), MISSED = 0, LÁTKA vždy Jekyll vypitím séra, K1 BOLEST jen za Hyda, odstranit `K2_LATKA_INSTABILITY`, zachovat `K1RookResolutionStyle` tam, kde krmí další důsledky. Závislost jen přes pojmenované události resolveru.
- [ ] [M] Rozhodnout bod A: konkrétní odměny za Jekyll a Hyde výsledek (včetně mind skill +1 za kapitolu K1–K7).
- [ ] [M] Rozhodnout bod B: smí medikace kompenzovat zmeškané motivy? Podle vzorců ne (potřeba AuthoringQuality + MotifClosure ≥ 120).
- [ ] [M] Rozhodnout bod C: kde v K2 po vypití séra vystoupí Hyde.
- [ ] [L] K2 TLD a kontrakt podle vzoru S1/K1 (po rozhodnutí A–C).
- [ ] [M] Schválit K2 TLD.
- [ ] [L] Aktualizovat `Koncept_JH_AMDD.docx` (zastaralý popis vyprchávání a zkreslení motivů).

**Brána 1a:** v masteru, TLD i kontraktech neexistuje FULFILLED ani TWISTED a K2 TLD je schválený. TLD dalších kapitol se pak vyrobí vždy těsně před jejich implementací, ne najednou.

## Fáze 2: Technický základ zdarma

Cíl: postavit vše, co jde bez peněz, v takové podobě, aby se později dalo vyměnit za koupený asset. Největší hodnota je logika hry, kterou Claude umí testovat sama bez hraní.

- [ ] [L] Architektura C++ modulů: story-state (persistent_state, hyde_dependence resolver, výsledky motivů, BookQuality), chapter manager (tok S0–S8 a K1–K8, route_check), data loader, tenká vrstva interakcí a dialogů.
- [ ] [L] Převodník `JH_MASTER.yaml` na JSON a DataTable/DataAsset, s validací proti masteru.
- [ ] [L] Automatické testy logiky: resolver závislosti, BookQuality a práh 60, route_check, přechody kapitol. Fungují bez spuštění hry a nahrazují část playtestu.
- [ ] [L] Vlastní tenké systémy místo placených balíčků: interakce (trace plus interface), dialogy (DataTable plus UMG), uložení (SaveGame), inventář a quick actions z masteru.
- [ ] [M] Stáhnout zdarma: Game Animation Sample (Fab), animace z Mixama (zdarma Adobe účet), MetaHuman (ověřit funkčnost na Macu), nabídky zdarma na Fab. U každého zkontrolovat licenci pro komerční prodej.
- [ ] [L] Asset registr (tabulka): název, zdroj, licence, funguje na Macu, komerčně OK. Nic se nepoužije bez zápisu.
- [ ] [M] První retarget na jedné postavě (Jekyll): IK Rig zdroj a cíl, IK Retargeter, hromadný retarget. Naučit se na jedné, zbytek je rutina.
- [ ] [L] Blender: příprava téže kostry a proporcí pro Hyda, aby používal stejný AnimBP a transformace byla výměna meshe.
- [ ] [L] Atmosféra z vestavěných nástrojů: Sky Atmosphere, Exponential Height Fog, Volumetric Clouds, Lumen, post-process (zrno, barevná paleta). Mlha je nejlevnější způsob, jak skrýt chybějící assety.

**Brána 2:** hratelná postava běhá v testovacím levelu s animacemi z Game Animation Sample, story-state vrstva načte master a testy projdou.

## Fáze 3: Vertikální řez S0 + K1 a Brána 1

Cíl: mít hratelný kus hry od začátku do konce a z něj zjistit, co zdarma nestačí. Teprve pak se rozhoduje o prvním nákupu.

- [ ] [L] Z TLD S0 a K1 sestavit rozpis: lokace, postavy, interakce, scény, použité systémy.
- [ ] [L] Graybox obou lokací přes MCP: správné měřítko, trasy, trigger zóny, rozmístění interakcí.
- [ ] [L] Logika K1: incident s Rookem, motivy, BOLEST jen za Hyda, LÁTKA s transformací, zápis do story-state.
- [ ] [M] Umělecký směr: paleta, světlo, nálada. Hodnotí screenshoty a dává zpětnou vazbu.
- [ ] [L] Aspoň jedna cutscene v Sequenceru: transformace Jekyll na Hyda, zakrytá střihem, mlhou a efekty (Niagara).
- [ ] [L] Dialogy z DataTable s titulky. Hlasy zatím placeholder (vlastní nahrávka), dabing až později.
- [ ] [M] První hudební motiv a placeholder pro hudební skládací mechaniku (import audia je ručně v editoru).
- [ ] [M] Playtest celého řezu od začátku do konce, poznámky co je nehratelné, nudné, nečitelné.
- [ ] [L] Opravy z playtestu, automatické testy logiky K1.
- [ ] [M] Sehnat Windows počítač na zkušební build (půjčit, cloud na hodiny). Ověřit, že řez běží i tam.
- [ ] [Chat] Nákupní seznam: pro každou položku problém, cena, alternativa zdarma, podpora Macu, licence.

**Brána 1 (první nákup):** řez je hratelný bez pádu, problémy jsou zapsané s důvodem a nákupní seznam je seřazen podle toho, co nejvíc zvedne dojem. Pravidla nákupu: jedna věc najednou, ověřit na Macu hned po instalaci, nejdřív prostředí a postavy (vzhled), až nakonec frameworky pro boj, dialogy a ukládání, které vlastní tenké vrstvy možná pokryjí.

## Fáze 4: Kapitolová smyčka K2–S8

Po Bráně 1 se každá další kapitola (v pořadí S1, K2, S2, K3 … S8) dělá stejným cyklem. Dokud se cyklus neosvědčí, dělejte jednu kapitolu najednou.

1. [L] TLD kapitoly a kumulativní kontrakt podle vzoru S1/K1. [M] schválí.
2. [L] Data: aktualizace master YAML, převodník, testy logiky.
3. [L] Graybox level a logika přes MCP, rozmístění interakcí a triggerů.
4. [M] Umělecký pass: které assety, světlo, atmosféra. [L] Doplní přes MCP a kontroluje screenshoty.
5. [L] Cutscény v Sequenceru, titulky, napojení audia. [M] dodá hudbu a nahrávky dabingu.
6. [M] Playtest kapitoly, poznámky. [L] opravy a testy.
7. [L] Aktualizace tohoto dokumentu a `CLAUDE.md`. [M] určí, co se škrtne, když kapitola vychází dráž, než má být.

**Cinematiky.** Primárně přímo v Unrealu (Sequencer), protože je to zdarma a vše zůstává konzistentní. Higgsfield a Seedance zatím odložit, dokud není zaplacený; pak jen pro vybrané klíčové scény a po vizuální shodě s hrou. Blender slouží na úpravy modelů, ne jako hlavní nástroj pro cutscény.

**Hudba.** Skládáte vy. Claude připraví seznam potřeb podle kapitol (nálada, délka, spouštěč) a napojí audio na události v editoru po vašem importu.

**Dabing.** Vaši lidé nahrávají podle repliky z TLD. Claude připraví exportní tabulku (ID repliky, postava, text, emoce), pojmenování souborů a napojení v DataTable. Placeholder hlasy nahrazujte po kapitolách, ne najednou.

**Brána kapitoly:** je hratelná od začátku do konce a nezhoršila předchozí kapitoly (automatické testy).

## Fáze 5: Leštění, Windows build, Steam

Tuto fázi nelze přeskočit, ale Steam stránku a Windows test je rozumné začít hodně dřív, než hra bude hotová.

- [ ] [L] Průchod výkonu: profilování, LOD, nastavení Lumen a Nanite, odstranění zbytečných systémů z masteru.
- [ ] [M] Windows build na Windows počítači, test na slabším hardwaru. Opakovat po každé kapitole, ne jen na konci.
- [ ] [L] Konfigurace packagingu, logování pádů, příprava Steamworks SDK (overlay, achievementy volitelně).
- [ ] [Chat] Finální kontrola licencí z asset registru, text pro oznámení použití AI obsahu na Steamu.
- [ ] [M] Steamworks účet a poplatek za aplikaci (kolem 100 USD, ověřit aktuální částku). Steam stránka: trailer, screenshoty, popis.
- [ ] [M] Zvážit zveřejnění stránky "Coming Soon" po hratelném řezu, aby se sbíraly wishlisty dřív.
- [ ] [M] Uzavřená beta s pár lidmi přes Steam klíče, sběr zpětné vazby.
- [ ] [L] Opravy z bety, release checklist.

K ověření: Epic požaduje 5 % royalty z hrubých příjmů nad 1 mil. USD a podmínky Fab/Steam se mění, proto je před vydáním ověřte na oficiálních stránkách.

**Brána 5:** release candidate prošel Windows testem i betou bez zásadních chyb.

## Rizika, škrty a impozantnost za málo peněz

Největší riziko není technika, ale rozsah: 17 kapitol a desítky systémů v masteru. Proto vertikální řez a průběžné škrtání.

| Riziko | Dopad | Reakce |
| --- | --- | --- |
| Zápis přes MCP nefunguje spolehlivě | pomalejší stavba levelů | Brána 0, plán B: Claude připravuje, level skládáte vy |
| Balíčky nebo MetaHuman nefungují na Macu | blokace postav | ověřit před nákupem, pro MetaHuman zvážit zapůjčený Windows |
| Retarget a animace zdlouhavé | zdržení | jedna kostra pro všechny, minimální sada animací, střih místo vlastní animace |
| Integrace cizích balíčků | chyby a závislosti | vlastní tenké vrstvy, kupovat pozdě a po jednom |
| Licence a AI disclosure | stažení ze Steamu | asset registr, kontrola u každého assetu |
| Rozpad designu mezi soubory | nekonzistentní hra | master jako zdroj pravdy, audit po každé změně |
| Mac zpomaluje smyčku (kompilace, shadery) | delší ladění | dávkovat změny, testy logiky bez spuštění hry |

**Škrtání při nouzi, v tomto pořadí:** 1. podpůrné systémy (kapsáři, stav obchodů, proměnlivé počasí), 2. počet lokací v kapitole, 3. zjednodušení boje za Hyda, 4. AI cinematiky z Higgsfieldu, 5. počet variant levelů podle author_packet.

**Impozantnost za málo:**

- Světlo, mlha a barevná gradace dělají víc než drahé assety. Viktoriánský Londýn v mlze je laciný a atmosférický.
- Stylizace (rytiny, tuš, knižní rukopis) odpouští chybějící realismus a hodí se k motivu rukopisu.
- Hudba, dabing a text jsou vaše silné stránky a nestojí nic navíc.
- Menší počet pečlivě dodělaných lokací je lepší než mnoho prázdných.
- Kamera a střih ve cutscénách zakryjí animace, které nemáte.

## Nejbližších 7 kroků

Hotové kroky odškrtávejte, zbytek dokumentu aktualizuje Claude.

- [x] [M] Souhlas s kopírováním `.mcp.json` do pracovní složky.
- [x] [L] Zkopírovat, ověřit, že se nástroje načtou přímo v relaci.
- [ ] [M] Zapnout Time Machine a Git zálohu (viz Fáze 0).
- [ ] [L] `.gitignore`, první commit, odkaz na tento plán do `CLAUDE.md`.
- [ ] [L] Zápisový test MCP v testovací mapě a build C++ z terminálu (Brána 0).
- [ ] [M] V lokální relaci spustit fázi 1 úlohy "MOTIVY OPRAVA JH", pouze audit bez zápisu.
- [ ] [M] Stáhnout zdarma Game Animation Sample a ověřit, že běží na Macu.
