using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;


namespace XaeroToJourneyMap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public String InstancePath { get; set; }
        public String SaveName { get; set; }

        List<Waypoint> wplist = new List<Waypoint>();
        private void btnSelectInstance_Click(object sender, EventArgs e)
        {
            fbdInstance.Description = "Browse to instance folder please";
            DialogResult dr = fbdInstance.ShowDialog();
            
            if(dr == DialogResult.OK)
            {
                String[] instanceNames = Directory.GetDirectories(fbdInstance.SelectedPath + "\\saves");
                foreach (String instanceName in instanceNames)
                {
                    cbSaves.Items.Add(instanceName.Split("\\").Last());
                }
                InstancePath = fbdInstance.SelectedPath;
                cbSaves.SelectedIndex = 0;
            }
        }

        public String getDimensionFromXaeroPath(string dimstring)
        {
            // There has to be a better way, but I'm not paid to find it ;p
            // Just define the static ones and assume the format is the same for all mod-added dimensions..
            if(dimstring == "dim%0")
            {
                return "minecraft:overworld";
            }
            else
            {
                return dimstring.Replace("dim%", "").Replace("$", ":");
            }
        }
        public List<Waypoint> getWaypointsFromDimension(String path, String dim)
        {
            string dpath = path + "\\" + dim + @"\waypoints.txt";

            StreamReader sr = new StreamReader(dpath);
            List<Waypoint> wps = new List<Waypoint>();

            
            while (!sr.EndOfStream)
            {
                String s = sr.ReadLine();
                if (s.StartsWith("#"))
                {
                    continue;
                }
                String[] ss = s.Split(":");
                Waypoint wp = new Waypoint
                {
                    name = ss[1],
                    initials = ss[2],
                    x = int.Parse(ss[3]),
                    y = int.Parse(ss[4]),
                    z = int.Parse(ss[5]),
                    color = int.Parse(ss[6]),
                    disabled = Boolean.Parse(ss[7]),
                    type = ss[8],
                    set = ss[9]
                };

                // massage it a bit for Journeymap, lazy way
                wp.enabled = !wp.disabled;
                Random r = new Random(wp.name.GetHashCode());
                wp.r = r.Next(255);
                wp.g = r.Next(255);
                wp.b = r.Next(255);
                wp.type = "Normal"; // Not sure what other options there are?
                wp.origin = "journeymap"; // not sure waht this actually does..
                wp.persistent = true;
                wp.showDeviation = false;
                wp.iconColor = -1;
                wp.customIconColor = false;

                wp.id = wp.name + "_" + wp.x + "-" + wp.y + "-" + wp.z; // Imitate JourneyMap's id and filename convention
                wp.JourneymapFilename = wp.id + ".json";
                
                wp.dimensions = new List<String>() { getDimensionFromXaeroPath(dim) };
                wps.Add(wp);
            }
            return wps;
        }
        private void btnLoadWaypoints_Click(object sender, EventArgs e)
        {
            String xaeropath = InstancePath + @"\XaeroWaypoints\" + SaveName;
            String[] dims = Directory.GetDirectories(xaeropath);

            foreach(string dim in dims)
            {
                List<Waypoint> wps = getWaypointsFromDimension(xaeropath, dim.Split("\\").Last());

                txtWaypoints.Text += "Waypoints in dim [ " + dim.Split("\\").Last() + "]:" + Environment.NewLine;
                foreach(Waypoint w in wps)
                {
                    txtWaypoints.Text += w.ToString() + Environment.NewLine;
                }
                txtWaypoints.Text += "Found " + wps.Count + " waypoints in dim [" + dim.Split("\\").Last() + "]" + Environment.NewLine;
                wplist.AddRange(wps);
            }
        }

        private void cbSaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveName = cbSaves.SelectedItem.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            String journeypath = InstancePath + @"\journeymap\data\sp\" + SaveName + @"\waypoints\";
            foreach (Waypoint wp in wplist)
            {
                String fname = wp.name + "_" + wp.x + "-" + wp.y + "-" + wp.z + ".json";
                File.WriteAllText(journeypath + fname, JsonConvert.SerializeObject(wp,Formatting.Indented));
            }
        }
    }
    public class Waypoint
    {
        public Waypoint() { }
        public override string ToString()
        {
            return string.Format("{0} : ({1},{2},{3})", name, x, y, z);
        }
        public String name { get; set; }
        [JsonIgnore]
        public String initials { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        [JsonIgnore]
        public int color { get; set; }
        [JsonIgnore]
        public Boolean disabled { get; set; }
        public String type { get; set; }
        [JsonIgnore]
        public String set { get; set; }

        public String id { get; set; }
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public Boolean enabled { get; set; }
        public List<string> dimensions { get; set; }
        public Boolean persistent { get; set; }
        public Boolean showDeviation { get; set; }
        public int iconColor { get; set; }
        public Boolean customIconColor { get; set; }
        public String icon = "journeymap:ui/img/waypoint-icon.png";
        public string colorizedIcon = "fake:color--130868-waypoint-icon.png";
        public String origin { get; set; }
        [JsonIgnore]
        public String JourneymapFilename { get; set; }
    }
}