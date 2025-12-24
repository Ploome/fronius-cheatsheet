namespace FroniusCheatSheet.Models;

public class Characteristic
{
    public string Name { get; set; } = "";
    public string[] Processes { get; set; } = [];
    public string Description { get; set; } = "";
    public string[] Tags { get; set; } = []; // For search filtering
}

public class WeldingProcess
{
    public string Name { get; set; } = "";
    public string ShortName { get; set; } = "";
    public string Description { get; set; } = "";
    public string HowItWorks { get; set; } = "";
    public string[] BestFor { get; set; } = [];
    public string[] Pros { get; set; } = [];
    public string[] Cons { get; set; } = [];
}

public class Scenario
{
    public string Situation { get; set; } = "";
    public string RecommendedProcess { get; set; } = "";
    public string RecommendedCharacteristic { get; set; } = "";
    public string Notes { get; set; } = "";
    public string[] Tags { get; set; } = [];
    public string[] Tips { get; set; } = []; // Execution tips for this scenario
}

public class Parameter
{
    public string Symbol { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsPrimary { get; set; }
}

public class TipSection
{
    public string Title { get; set; } = "";
    public string Icon { get; set; } = "";
    public string[] Tips { get; set; } = [];
}

public static class WeldingDatabase
{
    public static List<WeldingProcess> Processes => new()
    {
        new WeldingProcess
        {
            Name = "Standard",
            ShortName = "Standard",
            Description = "Traditional MIG - dip transfer at low power, spray at high power",
            HowItWorks = "Standard MIG/MAG across entire power range. Dip transfer at low power, intermediate arc in the middle (more spatter), spray arc at high power.",
            BestFor = ["Basic jobs", "When you want it to feel like a normal welder", "Thick plate"],
            Pros = ["Familiar feel", "Simple to understand", "Good for heavy work"],
            Cons = ["More spatter than advanced modes", "Less control"]
        },
        new WeldingProcess
        {
            Name = "Pulsed",
            ShortName = "Pulsed",
            Description = "Pulses between high/low current for controlled droplet transfer",
            HowItWorks = "Base current phase keeps arc barely stable and preheats workpiece. Pulsing current phase delivers precisely dosed pulse to detach one droplet of weld material.",
            BestFor = ["Cleaner welds", "Thinner material", "Out of position work"],
            Pros = ["Less spatter", "Better control", "Works across full power range"],
            Cons = ["Slightly more complex", "Can feel different to traditional MIG"]
        },
        new WeldingProcess
        {
            Name = "LSC (Low Spatter Control)",
            ShortName = "LSC",
            Description = "Modified short-circuit that drops current before the arc re-ignites",
            HowItWorks = "Before the short circuit bridge breaks, the current is LOWERED. Re-ignition happens at significantly lower current values. Result: way less spatter.",
            BestFor = ["Sheet metal", "Visible welds", "When you hate cleaning spatter"],
            Pros = ["Minimal spatter", "Clean welds", "Great for thin material"],
            Cons = ["Lower deposition rates", "Limited to dip transfer range"]
        },
        new WeldingProcess
        {
            Name = "PMC (Pulse Multi Control)",
            ShortName = "PMC",
            Description = "Advanced pulse with penetration & arc length stabilizers",
            HowItWorks = "Pulsed arc with high-speed data processing. Adds penetration stabilizer and arc length stabilizer for improved control. Machine constantly adjusts for optimal results.",
            BestFor = ["High-quality work", "Faster travel speeds", "Most versatile option"],
            Pros = ["Stable arc", "Even penetration", "Fast travel speeds", "Very versatile"],
            Cons = ["Requires understanding of settings", "Premium feature"]
        },
        new WeldingProcess
        {
            Name = "CMT (Cold Metal Transfer)",
            ShortName = "CMT",
            Description = "Wire physically reverses 170 times/second for ultra-low heat",
            HowItWorks = "The wire moves back and forth (reverses) at up to 170 Hz. This controlled droplet detachment during short circuit keeps current low. Result: virtually spatter-free with minimal heat input.",
            BestFor = ["Thin sheet", "Galvanized", "Aluminum", "Gap bridging", "Brazing"],
            Pros = ["Lowest heat input", "Almost no spatter", "Bridges gaps", "Minimal distortion"],
            Cons = ["Requires special CMT drive unit", "Lower deposition rate", "Slower"]
        }
    };

    public static List<Characteristic> Characteristics => new()
    {
        // Most commonly used
        new Characteristic { Name = "universal", Processes = ["CMT", "PMC", "Puls", "Standard"], Description = "The GO-TO setting for ALL standard welding tasks.", Tags = ["default", "general", "standard", "all-purpose"] },
        new Characteristic { Name = "dynamic", Processes = ["CMT", "PMC", "Puls", "Standard"], Description = "DEEP penetration, reliable root fusion at HIGH welding speeds.", Tags = ["penetration", "fast", "root", "hot"] },
        new Characteristic { Name = "root", Processes = ["CMT", "LSC", "Standard"], Description = "For ROOT PASSES with powerful arc.", Tags = ["root", "gap", "open root", "first pass"] },
        new Characteristic { Name = "open root", Processes = ["LSC", "CMT"], Description = "POWERFUL arc for ROOT PASSES with air gap.", Tags = ["root", "gap", "air gap", "open"] },
        new Characteristic { Name = "gap bridging", Processes = ["CMT", "PMC"], Description = "BEST gap-bridging ability due to VERY LOW heat input.", Tags = ["gap", "poor fitup", "bridging", "low heat"] },
        new Characteristic { Name = "galvanized", Processes = ["CMT", "LSC", "PMC", "Puls", "Standard"], Description = "For GALVANIZED sheet - LOW risk of zinc pores and reduced penetration.", Tags = ["galvanized", "zinc", "coated", "sheet"] },
        new Characteristic { Name = "cladding", Processes = ["CMT", "LSC", "PMC"], Description = "OVERLAY welding - LOW penetration, LOW dilution, WIDE weld seam, improved wetting.", Tags = ["overlay", "cladding", "buildup", "wide bead"] },
        new Characteristic { Name = "pipe", Processes = ["PMC", "Pulse", "Standard"], Description = "For PIPE applications and positional welding on narrow gap applications.", Tags = ["pipe", "positional", "narrow gap"] },
        new Characteristic { Name = "retro", Processes = ["CMT", "Puls", "PMC", "Standard"], Description = "Same weld properties as the old TransPuls Synergic (TPS) series. Legacy mode.", Tags = ["legacy", "old", "transpuls", "classic"] },

        // AC modes
        new Characteristic { Name = "AC additive", Processes = ["PMC", "CMT"], Description = "For bead-on-bead on adaptive structures. Flips polarity to keep heat LOW but still get HIGH deposition. More stable arc.", Tags = ["AC", "additive", "low heat", "deposition"] },
        new Characteristic { Name = "AC heat control", Processes = ["PMC", "CMT"], Description = "Flips polarity to keep heat into workpiece LOW. You can fine-tune heat with correction parameters.", Tags = ["AC", "heat control", "low heat"] },
        new Characteristic { Name = "AC universal", Processes = ["PMC", "CMT"], Description = "Flips polarity to keep heat LOW. Good for ALL standard welding tasks.", Tags = ["AC", "universal", "low heat"] },

        // ADV modes
        new Characteristic { Name = "additive", Processes = ["CMT"], Description = "Reduced heat, greater stability, HIGHER deposition rate. For bead-on-bead on adaptive structures.", Tags = ["additive", "deposition", "buildup"] },
        new Characteristic { Name = "ADV (CMT)", Processes = ["CMT"], Description = "Needs inverter module. Alternating current process. Negative polarity phase = LOW heat + HIGH deposition.", Tags = ["ADV", "advanced", "AC", "deposition"] },
        new Characteristic { Name = "ADV (LSC)", Processes = ["LSC"], Description = "Needs electronic switch. Maximum current reduction by opening circuit in each process phase. Only works with TPS 400i LSC ADV.", Tags = ["ADV", "advanced", "LSC", "low spatter"] },
        new Characteristic { Name = "ADV braze", Processes = ["CMT"], Description = "For BRAZING - reliable wetting, good flow of braze material. Almost NO spatter in dip transfer. Good for long hosepacks.", Tags = ["braze", "brazing", "ADV"] },
        new Characteristic { Name = "ADV root", Processes = ["LSC Advanced"], Description = "For ROOT PASSES with powerful arc. Almost no spatter in dip transfer. Good for long hosepacks.", Tags = ["root", "ADV", "advanced"] },
        new Characteristic { Name = "ADV universal", Processes = ["LSC Advanced"], Description = "For ALL standard tasks. Almost no spatter in dip transfer. Good for long hosepacks.", Tags = ["universal", "ADV", "advanced"] },

        // Specialty
        new Characteristic { Name = "arc blow", Processes = ["PMC"], Description = "Avoids arc breaks from arc blow (magnetic issues).", Tags = ["arc blow", "magnetic", "arc problems"] },
        new Characteristic { Name = "arcing", Processes = ["Standard"], Description = "For HARDFACING on wet or dry surfaces. Think grinding rollers, sugar/ethanol industries.", Tags = ["hardfacing", "arcing", "wear"] },
        new Characteristic { Name = "base", Processes = ["Standard"], Description = "Same as arcing - hardfacing on wet/dry surfaces.", Tags = ["hardfacing", "base", "wear"] },
        new Characteristic { Name = "braze", Processes = ["CMT", "LSC", "PMC"], Description = "For BRAZING - reliable wetting, good braze flow.", Tags = ["braze", "brazing"] },
        new Characteristic { Name = "braze+", Processes = ["CMT"], Description = "Brazing with special Braze+ gas nozzle. HIGH brazing speed (narrow opening, high flow rate).", Tags = ["braze", "brazing", "fast"] },
        new Characteristic { Name = "CC/CV", Processes = ["CC/CV"], Description = "Constant Current OR Constant Voltage curve. For running with power supply unit - NO wirefeeder needed.", Tags = ["CC", "CV", "constant current", "constant voltage"] },
        new Characteristic { Name = "constant current", Processes = ["PMC"], Description = "Constant current mode. For when you DON'T need arc length control (stickout changes won't be compensated).", Tags = ["constant current", "CC"] },
        new Characteristic { Name = "CW additive", Processes = ["PMC", "ConstantWire"], Description = "Constant wire speed for additive production. NO ARC - wire is just fed as filler metal.", Tags = ["constant wire", "additive", "no arc"] },
        new Characteristic { Name = "dynamic +", Processes = ["PMC"], Description = "SHORT arc length for HIGH welding speeds. Arc length control is independent of material surface.", Tags = ["dynamic", "fast", "short arc"] },
        new Characteristic { Name = "edge", Processes = ["CMT"], Description = "For CORNER SEAMS - targeted energy input, high welding speed.", Tags = ["corner", "edge", "seam"] },
        new Characteristic { Name = "flanged edge", Processes = ["CMT"], Description = "For FLANGE WELDS - targeted energy input, high welding speed.", Tags = ["flange", "edge"] },
        new Characteristic { Name = "galvannealed", Processes = ["PMC"], Description = "For iron-zinc-coated material surfaces.", Tags = ["galvannealed", "zinc", "coated"] },
        new Characteristic { Name = "hotspot", Processes = ["CMT"], Description = "Hot start sequence for PLUG WELDS and MIG/MAG SPOT WELD joints.", Tags = ["plug weld", "spot weld", "hotspot"] },

        // LaserHybrid
        new Characteristic { Name = "LH fillet weld", Processes = ["PMC"], Description = "For LaserHybrid FILLET WELD applications (laser + MIG/MAG).", Tags = ["laser", "hybrid", "fillet"] },
        new Characteristic { Name = "LH flange weld", Processes = ["PMC"], Description = "For LaserHybrid CORNER WELD applications (laser + MIG/MAG).", Tags = ["laser", "hybrid", "flange", "corner"] },
        new Characteristic { Name = "LH Inductance", Processes = ["PMC"], Description = "For LaserHybrid with HIGH welding circuit inductance (laser + MIG/MAG).", Tags = ["laser", "hybrid", "inductance"] },
        new Characteristic { Name = "LH lap joint", Processes = ["PMC", "CMT"], Description = "For LaserHybrid LAP JOINT applications (laser + MIG/MAG).", Tags = ["laser", "hybrid", "lap"] },
        new Characteristic { Name = "marking", Processes = [], Description = "For MARKING electrically conductive surfaces.", Tags = ["marking", "etching"] },

        // Mix modes (ripple effect)
        new Characteristic { Name = "mix (PMC)", Processes = ["PMC"], Description = "Needs Pulse + PMC packages. Creates RIPPLED WELD - heat controlled by cycling between pulsed and dip transfer arc.", Tags = ["mix", "ripple", "TIG look"] },
        new Characteristic { Name = "mix (CMT)", Processes = ["CMT"], Description = "Needs CMT drive unit + WF 60i Robacta Drive CMT. Creates RIPPLED WELD - cycles between pulsed arc and CMT.", Tags = ["mix", "ripple", "TIG look"] },
        new Characteristic { Name = "mix drive", Processes = ["PMC"], Description = "Needs PushPull drive unit. Creates RIPPLED WELD by cycling pulsed process with extra wire movement.", Tags = ["mix", "ripple", "TIG look"] },
        new Characteristic { Name = "multi arc", Processes = ["PMC"], Description = "For when MULTIPLE ARCS influence each other. Good for increased circuit inductance or mutual welding circuit coupling.", Tags = ["multi arc", "tandem", "inductance"] },

        // PCS modes
        new Characteristic { Name = "PCS", Processes = ["PMC"], Description = "Switches from pulsed arc to concentrated SPRAY ARC above a certain power. Combines advantages of both in one setting.", Tags = ["PCS", "spray", "pulse"] },
        new Characteristic { Name = "PCS mix", Processes = ["PMC"], Description = "Cycles between pulsed and spray arc to dip transfer, depending on power range. Great for VERTICAL-UP welds (hot/cold alternating).", Tags = ["PCS", "vertical", "positional"] },

        // Pin modes
        new Characteristic { Name = "pin", Processes = ["CMT"], Description = "For welding BRADS/STUDS to conductive surfaces. Wire retraction and current curve define pin appearance.", Tags = ["pin", "stud", "brad"] },
        new Characteristic { Name = "pin picture", Processes = ["CMT"], Description = "For welding brads with SPHERICAL END - for creating pin pictures.", Tags = ["pin", "picture", "art"] },
        new Characteristic { Name = "pin print", Processes = ["CMT"], Description = "For writing TEXTS, PATTERNS, or MARKINGS by positioning individual dots.", Tags = ["pin", "print", "marking", "text"] },
        new Characteristic { Name = "pin spike", Processes = ["CMT"], Description = "For welding brads with POINTED ENDS onto conductive surfaces.", Tags = ["pin", "spike", "pointed"] },

        // Pipe specific
        new Characteristic { Name = "pipe cladding", Processes = ["PMC", "CMT"], Description = "OVERLAY welding on outer pipe claddings - little penetration, low dilution, wide weld seam.", Tags = ["pipe", "cladding", "overlay"] },
        new Characteristic { Name = "ripple drive", Processes = ["PMC"], Description = "Needs CMT drive unit. Creates RIPPLED WELD (TIG-like appearance) by cycling pulsed process with wire movement.", Tags = ["ripple", "TIG look", "stacked dimes"] },
        new Characteristic { Name = "seam track", Processes = ["PMC", "Pulse"], Description = "Amplified current control for use with SEAM TRACKING systems with external current measurement.", Tags = ["seam tracking", "automation", "robot"] },
        new Characteristic { Name = "TIME", Processes = ["PMC"], Description = "For VERY LONG STICKOUT with TIME shielding gases. Increases deposition rate. (TIME = Transferred Ionized Molten Energy)", Tags = ["TIME", "long stickout", "deposition"] },

        // TWIN (Tandem)
        new Characteristic { Name = "TWIN cladding", Processes = ["PMC"], Description = "MIG/MAG TANDEM - overlay welding with low penetration, low dilution, wide weld seam.", Tags = ["twin", "tandem", "cladding"] },
        new Characteristic { Name = "TWIN multi arc", Processes = ["PMC"], Description = "MIG/MAG TANDEM - for when multiple arcs influence each other. Good for circuit inductance/coupling issues.", Tags = ["twin", "tandem", "multi arc"] },
        new Characteristic { Name = "TWIN PCS", Processes = ["PMC"], Description = "MIG/MAG TANDEM - switches from pulsed to spray arc above certain power. Arcs NOT synchronized.", Tags = ["twin", "tandem", "PCS"] },
        new Characteristic { Name = "TWIN universal", Processes = ["PMC", "Pulse", "CMT"], Description = "MIG/MAG TANDEM - for all standard tasks. Optimized for mutual magnetic arc interaction. Arcs NOT synchronized.", Tags = ["twin", "tandem", "universal"] },
        new Characteristic { Name = "weld+", Processes = ["CMT"], Description = "For welding with SHORT STICKOUT and Braze+ gas nozzle (small opening, high flow velocity).", Tags = ["weld+", "short stickout", "braze nozzle"] }
    };

    public static List<Scenario> Scenarios => new()
    {
        new Scenario {
            Situation = "General steel fabrication",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "universal",
            Notes = "Your bread and butter - works for most steel jobs",
            Tags = ["steel", "general", "fabrication"],
            Tips = [
                "Start with arc length at 0, adjust ±2 if needed",
                "Dynamics around middle - increase for mill scale",
                "15-20° drag angle for good penetration",
                "3/4\" stickout is typical"
            ]
        },
        new Scenario {
            Situation = "Thin gauge sheet (<2mm)",
            RecommendedProcess = "CMT or LSC",
            RecommendedCharacteristic = "universal or galvanized",
            Notes = "Low heat = less burn-through and warping",
            Tags = ["thin", "sheet", "gauge"],
            Tips = [
                "Keep arc length SHORT (-2 to -3) to focus heat",
                "Dynamics LOW to reduce dig",
                "Move FAST - don't let heat build up",
                "Tack frequently to control warping",
                "CMT if you're still burning through with LSC"
            ]
        },
        new Scenario {
            Situation = "Root pass with gap",
            RecommendedProcess = "LSC or CMT",
            RecommendedCharacteristic = "root or open root",
            Notes = "Powerful arc, handles gaps well",
            Tags = ["root", "gap", "first pass"],
            Tips = [
                "Arc length: LONGER (+2 to +4) for bigger gaps",
                "Watch the keyhole - fill it as you go",
                "Increase I-S (hot start) if starts lack fusion",
                "Travel speed: not too slow or you'll burn through",
                "Bump dynamics DOWN if blowing holes"
            ]
        },
        new Scenario {
            Situation = "Fill & cap passes",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "dynamic or universal",
            Notes = "Good penetration with fast travel speeds",
            Tags = ["fill", "cap", "cover"],
            Tips = [
                "Use 'dynamic' for more penetration into root",
                "Weave or stringer - match to joint width",
                "Watch tie-ins at toes - avoid undercut",
                "Slight drag angle (10-15°) for caps",
                "Let previous pass cool if stacking"
            ]
        },
        new Scenario {
            Situation = "Vertical up",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "PCS mix",
            Notes = "Hot/cold cycling helps build a shelf",
            Tags = ["vertical", "uphill", "positional"],
            Tips = [
                "PCS mix cycles hot/cold - puddle freezes on cold phase",
                "Small weave, pause at toes to fill",
                "Keep arc on leading edge of puddle",
                "If puddle drips: speed up or lower heat",
                "Dynamics moderate - too high and it drips"
            ]
        },
        new Scenario {
            Situation = "Aluminum",
            RecommendedProcess = "Pulsed or CMT",
            RecommendedCharacteristic = "universal",
            Notes = "CMT for thin, pulse for thick",
            Tags = ["aluminum", "aluminium", "alloy"],
            Tips = [
                "CLEAN the aluminum - wire brush or acetone",
                "Pure argon gas only",
                "Push angle (10-15°) - never drag on aluminum",
                "Preheat thick sections to prevent cracking",
                "CMT for thin stuff - lowest heat possible"
            ]
        },
        new Scenario {
            Situation = "Stainless - General",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "universal",
            Notes = "Keep heat LOW to avoid sugaring. Use tri-mix or 98/2 gas.",
            Tags = ["stainless", "SS", "304", "316", "general"],
            Tips = [
                "Gas: tri-mix or 98% Ar / 2% CO2",
                "Arc length SHORT (-2 to -4) - concentrate heat",
                "Travel FAST - don't let heat build",
                "Interpass temp max 300°F for 304/316",
                "Stainless brush only - no carbon contamination"
            ]
        },
        new Scenario {
            Situation = "Stainless - Open Root",
            RecommendedProcess = "LSC or CMT",
            RecommendedCharacteristic = "root or open root",
            Notes = "LSC gives control, CMT for thin wall. Back purge if you can!",
            Tags = ["stainless", "SS", "root", "open root", "pipe"],
            Tips = [
                "BACK PURGE with argon - prevents sugaring",
                "Arc length SHORT (-2 to -4)",
                "Keyhole should be small and controlled",
                "CMT for thin wall pipe - less burn-through risk",
                "Dam both ends if purging pipe"
            ]
        },
        new Scenario {
            Situation = "Stainless - Fill & Cap",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "dynamic or universal",
            Notes = "Watch interpass temp! Let it cool between passes. Stainless holds heat.",
            Tags = ["stainless", "SS", "fill", "cap", "cover"],
            Tips = [
                "Let it COOL between passes - 300°F max",
                "Move faster than carbon steel",
                "Smaller weld pool than you'd expect",
                "Stringer beads often better than weave",
                "Check color - purple/blue means too hot"
            ]
        },
        new Scenario {
            Situation = "Stainless - Thin Wall Pipe",
            RecommendedProcess = "CMT",
            RecommendedCharacteristic = "universal or root",
            Notes = "CMT's low heat prevents burn-through and sugaring. Back purge critical!",
            Tags = ["stainless", "SS", "pipe", "thin wall", "tube"],
            Tips = [
                "CMT is your best friend here - lowest heat",
                "Back purge is NON-NEGOTIABLE",
                "Tight keyhole, don't let it open up",
                "Travel speed: find the sweet spot",
                "If sugaring: more purge, less heat, faster travel"
            ]
        },
        new Scenario {
            Situation = "Stainless - Avoiding Sugaring",
            RecommendedProcess = "CMT or LSC",
            RecommendedCharacteristic = "universal",
            Notes = "Lower heat input = less oxidation on backside. Shorten arc length (-2 to -5).",
            Tags = ["stainless", "SS", "sugaring", "oxidation", "backside"],
            Tips = [
                "Sugaring = oxidation from heat on backside",
                "Arc length SHORT (-2 to -5) - focus the heat",
                "CMT or LSC for lowest heat input",
                "Back purge with argon when possible",
                "Travel faster, smaller weld pool"
            ]
        },
        new Scenario {
            Situation = "Galvanized material",
            RecommendedProcess = "Any",
            RecommendedCharacteristic = "galvanized",
            Notes = "Reduces zinc blowout and porosity",
            Tags = ["galvanized", "zinc", "coated"],
            Tips = [
                "Galvanized characteristic = optimized for zinc",
                "VENTILATION - zinc fumes are nasty",
                "Expect more spatter than bare steel",
                "Longer arc (+) helps zinc escape",
                "Grind zinc off if porosity is bad"
            ]
        },
        new Scenario {
            Situation = "Brazing",
            RecommendedProcess = "CMT",
            RecommendedCharacteristic = "braze or ADV braze",
            Notes = "Wire reversal helps braze material flow",
            Tags = ["braze", "brazing", "bronze"],
            Tips = [
                "CMT wire reversal = perfect for brazing",
                "Keep heat LOW - you're flowing, not melting base",
                "Push angle to direct heat forward",
                "Braze wire (CuSi3 etc) not steel wire",
                "Clean joint - flux helps wetting"
            ]
        },
        new Scenario {
            Situation = "Pretty TIG-looking beads",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "ripple drive or mix",
            Notes = "Creates stacked dime look. Or use SynchroPulse!",
            Tags = ["TIG", "pretty", "ripple", "stacked dimes", "synchropulse"],
            Tips = [
                "Ripple drive or mix = wire cycles for ripple effect",
                "Alternative: SynchroPulse on any process",
                "Slow, steady travel for even ripples",
                "Match frequency to travel speed",
                "Clean material = cleaner looking bead"
            ]
        },
        new Scenario {
            Situation = "SynchroPulse - Stacked Dimes",
            RecommendedProcess = "PMC or Pulsed",
            RecommendedCharacteristic = "universal + SynchroPulse ON",
            Notes = "Enable SynchroPulse, set frequency 1-3 Hz, amplitude 20-40%.",
            Tags = ["synchropulse", "TIG", "ripple", "stacked dimes", "cosmetic"],
            Tips = [
                "Enable: Process params → SynchroPulse → ON",
                "Frequency: 1.5-2.5 Hz for nice spacing",
                "Amplitude: 30-40% for visible ripple",
                "Match travel speed to frequency",
                "Slower = tighter ripples, faster = spread out"
            ]
        },
        new Scenario {
            Situation = "Poor fit-up / big gaps",
            RecommendedProcess = "CMT",
            RecommendedCharacteristic = "gap bridging",
            Notes = "Lowest heat = best gap bridging ability",
            Tags = ["gap", "fitup", "poor fit"],
            Tips = [
                "CMT gap bridging = maximum forgiveness",
                "Arc length LONGER (+3 to +5) to bridge",
                "Dynamics LOW - don't blow through",
                "Weave to tie in both sides",
                "Multiple passes if gap is huge"
            ]
        },
        new Scenario {
            Situation = "Overlay / hardfacing",
            RecommendedProcess = "CMT or PMC",
            RecommendedCharacteristic = "cladding",
            Notes = "Low penetration, low dilution, wide bead",
            Tags = ["overlay", "hardfacing", "cladding", "buildup"],
            Tips = [
                "Cladding = LOW penetration by design",
                "Wide weave for coverage",
                "Overlap passes 30-50%",
                "Keep it flat - gravity helps",
                "Preheat if hardfacing wire requires it"
            ]
        },
        new Scenario {
            Situation = "Pipe welding",
            RecommendedProcess = "PMC or Standard",
            RecommendedCharacteristic = "pipe",
            Notes = "Optimized for positional work around pipe",
            Tags = ["pipe", "tube", "positional"],
            Tips = [
                "Pipe characteristic handles position changes",
                "6G = all positions - adjust as you go",
                "Uphill for root/hot pass typically",
                "Watch tie-ins at 6 o'clock",
                "Consistent travel speed around the clock"
            ]
        },
        new Scenario {
            Situation = "Spot/plug welds",
            RecommendedProcess = "CMT",
            RecommendedCharacteristic = "hotspot",
            Notes = "Hot start sequence for plug welds",
            Tags = ["spot", "plug", "tack"],
            Tips = [
                "Hotspot = timed weld sequence",
                "Set spot time (SPt) for how long to weld",
                "Keep gun perpendicular to work",
                "Consistent pressure and position",
                "Good for sheet metal lap joints"
            ]
        },
        new Scenario {
            Situation = "Arc blow problems",
            RecommendedProcess = "PMC",
            RecommendedCharacteristic = "arc blow",
            Notes = "Prevents magnetic arc wander",
            Tags = ["arc blow", "magnetic", "wander"],
            Tips = [
                "Arc blow = magnetic field pushing arc around",
                "This characteristic compensates for it",
                "Also try: move ground clamp position",
                "Weld toward your ground when possible",
                "DC issues - AC process eliminates it"
            ]
        }
    };

    public static List<Parameter> Parameters => new()
    {
        // Primary
        new Parameter { Symbol = "Thickness", Name = "Material Thickness", Description = "THE MAIN INPUT - machine calculates WFS, voltage, everything else from this. Set based on what you're welding.", IsPrimary = true },
        new Parameter { Symbol = "Arc Length", Name = "Arc Length Correction", Description = "Makes arc longer (+) or shorter (-). Range is typically -10 to +10. SHORTER arc (-): more penetration, narrower bead, better for roots & stainless. LONGER arc (+): wider bead, more forgiving on gaps, less dig. Start at 0, adjust by 1-2 at a time.", IsPrimary = true },
        new Parameter { Symbol = "Dynamics", Name = "Dynamics / Arc Force", Description = "How aggressive the arc responds. Turn UP for more dig (mill scale, dirty metal). Turn DOWN if too harsh/blowing holes.", IsPrimary = true },

        // Secondary
        new Parameter { Symbol = "GPr", Name = "Gas Pre-flow", Description = "How long gas flows BEFORE arc starts. Protects weld pool from contamination at start.", IsPrimary = false },
        new Parameter { Symbol = "GPo", Name = "Gas Post-flow", Description = "How long gas flows AFTER arc stops. Protects hot weld from atmosphere.", IsPrimary = false },
        new Parameter { Symbol = "I-S", Name = "Starting Current", Description = "Hot start current. Base material heats up FAST at weld start. Helps on cold/thick material.", IsPrimary = false },
        new Parameter { Symbol = "t-S", Name = "Starting Current Time", Description = "HOW LONG the starting current phase lasts.", IsPrimary = false },
        new Parameter { Symbol = "SL1", Name = "Slope 1 (Up-slope)", Description = "How fast current RAMPS UP from start current to main welding current. Smooth transition in.", IsPrimary = false },
        new Parameter { Symbol = "I", Name = "Welding Current", Description = "The MAIN welding phase. Uniform heat into base material.", IsPrimary = false },
        new Parameter { Symbol = "I-E", Name = "Final Current", Description = "Crater fill current. Drops at END to prevent local overheating. Stops weld seam drop-through.", IsPrimary = false },
        new Parameter { Symbol = "t-E", Name = "Final Current Time", Description = "HOW LONG the final/crater fill current phase lasts.", IsPrimary = false },
        new Parameter { Symbol = "SL2", Name = "Slope 2 (Down-slope)", Description = "How fast welding current RAMPS DOWN to final current. Smooth crater fill.", IsPrimary = false },
        new Parameter { Symbol = "Arc S", Name = "Start Arc Length", Description = "Arc length correction at START of weld.", IsPrimary = false },
        new Parameter { Symbol = "Arc E", Name = "End Arc Length", Description = "Arc length correction at END of weld.", IsPrimary = false },
        new Parameter { Symbol = "SPt", Name = "Spot Welding Time", Description = "For spot/tack welds - how long the weld runs.", IsPrimary = false }
    };

    public static List<TipSection> TipSections => new()
    {
        new TipSection
        {
            Title = "Arc Length Correction - When & How",
            Icon = "straighten",
            Tips = [
                "Range is -10 to +10. Start at 0, adjust 1-2 at a time until it feels right.",
                "SHORTER arc (-1 to -5): Tighter, more focused arc. More penetration, narrower bead. Great for roots and stainless.",
                "LONGER arc (+1 to +5): Wider, softer arc. Better gap bridging, more forgiving. Good for fill passes and poor fit-up.",
                "Stubbing into the puddle? Go LONGER (+). Arc wandering/unstable? Go SHORTER (-).",
                "Stainless steel: Run SHORT (-2 to -5) to concentrate heat and reduce sugaring on backside.",
                "Open roots with gap: Try LONGER (+2 to +4) to help bridge without burning through.",
                "If you change wire stickout, you may need to re-adjust arc length to compensate."
            ]
        },
        new TipSection
        {
            Title = "Stainless Steel Tips",
            Icon = "science",
            Tips = [
                "HEAT IS THE ENEMY. Stainless holds heat and wants to warp and sugar. Keep it cool.",
                "Use tri-mix (90% He, 7.5% Ar, 2.5% CO2) or 98% Ar / 2% CO2 for cleaner welds.",
                "Back purge your roots! Argon on the backside prevents sugaring (oxidation).",
                "Watch interpass temp - let it cool between passes. 300°F max for 304/316.",
                "Shorter arc length (-2 to -5) concentrates heat, reduces overall heat input.",
                "CMT or LSC for roots - the low heat input helps prevent burn-through and sugaring.",
                "PMC with 'universal' for fill/cap - but move FAST to keep heat input down.",
                "Stainless doesn't conduct heat away like carbon steel - smaller weld pool, faster travel.",
                "Wire brush with STAINLESS brush only. Carbon steel contamination = rust later."
            ]
        },
        new TipSection
        {
            Title = "Open Root Tips",
            Icon = "radio_button_unchecked",
            Tips = [
                "LSC 'root' or 'open root' characteristic gives you a powerful, controllable arc.",
                "CMT 'root' for thin wall - the wire reversal helps bridge gaps without burn-through.",
                "Gap too big? Go LONGER arc (+) and slightly LOWER dynamics to reduce dig.",
                "Gap tight/no gap? SHORTER arc (-) for more penetration, bump dynamics UP slightly.",
                "Land too thick? Increase dynamics for more dig. Land too thin? Back off dynamics.",
                "Keyhole technique: Watch the back of the keyhole, not the front. Fill it as you go.",
                "Stainless roots: Back purge is critical! Argon dam or purge the whole pipe.",
                "Travel speed matters: Too slow = burn-through. Too fast = lack of fusion. Find the sweet spot.",
                "Hot start (I-S) helps on cold starts. Increase if your starts are cold/lack fusion."
            ]
        },
        new TipSection
        {
            Title = "Dynamics / Arc Force - Dialing It In",
            Icon = "offline_bolt",
            Tips = [
                "Dynamics controls how hard the arc 'digs' and how it responds to changes.",
                "HIGHER dynamics: More aggressive arc, more penetration, punches through mill scale and dirt.",
                "LOWER dynamics: Softer arc, less dig, more forgiving on thin material and gaps.",
                "Blowing holes? Turn dynamics DOWN. Lack of fusion/cold lap? Turn dynamics UP.",
                "Dirty or rusty steel: Crank dynamics UP to burn through the crud.",
                "Clean material, good fit-up: Keep dynamics moderate or low for smooth arc.",
                "Vertical up: Moderate dynamics helps control the puddle without it dripping.",
                "Combined with arc length: Short arc + high dynamics = maximum penetration. Long arc + low dynamics = maximum forgiveness."
            ]
        },
        new TipSection
        {
            Title = "SynchroPulse - TIG-Look Ripple Beads",
            Icon = "waves",
            Tips = [
                "SynchroPulse creates that stacked-dime TIG appearance by cycling between HIGH and LOW power.",
                "Works with: Standard, Pulsed, LSC, and PMC processes. Most common with PMC or Pulsed.",
                "ENABLE IT: Process parameters → SynchroPulse → turn it ON. Then set your frequency and amplitude.",
                "FREQUENCY (Hz): How many ripples per second. 1-2 Hz = wide spacing (like slow TIG). 3-5 Hz = tighter ripples. Start at 2 Hz.",
                "AMPLITUDE (%): How big the power swing is. Higher = more pronounced ripple. 20-30% for subtle, 40-50% for bold ripples.",
                "DUTY CYCLE: Ratio of high to low power time. 50% = equal. Higher = more time at high power (hotter average).",
                "For COSMETIC welds: Try 1.5-2.5 Hz frequency, 30-40% amplitude. Adjust to match your travel speed.",
                "Travel speed matters! Slower travel = ripples stack tighter. Faster = ripples spread out. Match frequency to your speed.",
                "Vertical up: SynchroPulse helps control the puddle - the LOW phase lets the puddle freeze slightly.",
                "Too much spatter? Lower the amplitude. Ripples too subtle? Increase amplitude or slow down.",
                "Stainless with SynchroPulse: The pulsing helps control heat input while still getting that pretty bead."
            ]
        }
    };
}
