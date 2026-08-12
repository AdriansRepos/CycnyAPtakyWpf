# 🐥 Cycny & Ptáky WPF (v1.0)

> **Inovativní sociálně-diagnostický software pro objektivní analýzu osobních proporcí a okamžitou zpětnou vazbu.**

Aplikace **Cycny & Ptáky** představuje vrchol interaktivní psychologie spojené s moderním WPF vývojem. Dovoluje uživateli zvolit si pohlaví, položí zásadní životní otázku a nenechá ho lhát.

---

## ⚡ Hlavní Funkce

* **Personalizovaná diagnostika:** Dynamická úprava otázky na základě volby pohlaví (*Muž* vs. *Žena*).
* **Algoritmus neuniknutelné pravdy:** Pokusí-li se uživatel v potvrzovacím okně zapírat a kliknout na *ANO*, tlačítko pomocí deterministického náhodného algoritmu bezpodmínečně uteče po ploše plátna.
* **Bleskový smích (Zero-Latency Video Playback):** Využívá pokročilý trik s přednačtením videa do paměti RAM pro okamžité spuštění reakce bez zpoždění dekodéru.
* **Ochranná záloha:** Pokud chybí soubor videa, systém má v sobě zabudovaný fallback v podobě klasického `MessageBoxu`.

---

## 🛠️ Technické vychytávky z kódu

### 1. Optimalizace přehrávání videa (`Zero-Latency RAM Cache`)

Aby reakce na přiznání byla okamžitá a bez záseku přehrávače, aplikace při startu provede rychlé přednačtení do RAM:

```csharp
mediaPlayer.Play();
mediaPlayer.Pause();
mediaPlayer.Position = TimeSpan.Zero;

```

Tím donutí WPF rámec dekódovat prvky videa do paměti ještě předtím, než uživatel stiskne tlačítko.

### 2. Dynamické utíkající tlačítko (`Canvas Physics`)

V potvrzovacím dialogu `PotvrzeniWindow` se při události `MouseEnter` přepočítávají hranice plátna (`ActualWidth` / `ActualHeight`) a tlačítko nekompromisně odskáče na náhodné souřadnice, čímž znemožní uživateli nepravdivou odpověď.

---

## 📦 Instalace & První spuštění

Tato verze v1.0 obsahuje plnohodnotný instalátor vytvořený v **Inno Setup**.

1. Stáhněte si nejnovější instalátor `CycnyAPtaky_Setup_v1.0.exe`.
2. Projděte průvodcem instalace (vytvoří zástupce na ploše i v nabídce Start).
3. Ujistěte se, že ve složce s aplikací zůstal soubor `smich.mp4` pro plnohodnotný audio-vizuální zážitek.

---

## 📂 Struktura projektu

```text
CycnyAPtakyWpf/
├── MainWindow.xaml (.cs)      # Hlavní okno, výběr pohlaví & správa video prehrávače
├── PotvrzeniWindow.xaml (.cs) # Modální okno s utíkajícím tlačítkem
├── smich.mp4                  # Klíčový multimediální asset
├── app.ico                    # Vlastní ikona aplikace a setupu
└── CycnyAPtaky_Setup_v1.0.iss # Inno Setup skript

```

---

## ⚙️ Požadavky

* **OS:** Windows 10 / 11
* **Runtime:** .NET 6.0 Desktop Runtime (nebo novější)

---

*Vytvořeno pro pobavení s důrazem na čistý C# WPF kód a svižné UI.*