using EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Timers;
using System.Diagnostics;

namespace CSharpEksamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Salgsudbud> getSalgsudbud()
        {
            using (var ctx = new EksamenDatabaseEntities())
            {
                var salgsudbud = ctx.Salgsudbuds.ToList();
                return salgsudbud;
            }
        }

        public List<Købstilbud> getKøbstilbud()
        {
            using (var ctx = new EksamenDatabaseEntities())
            {
                var købstilbud = ctx.Købstilbud.Include(x => x.Køber).ToList();
                købstilbud.Sort((x, y) => y.pris.CompareTo(x.pris));
                return købstilbud;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            foreach (Salgsudbud s in getSalgsudbud())
            {
                lvwSalgsudbud.Items.Add(s.SalgsudbudId);
            }
        }

        private void lvwSalgsudbud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvwSalgsudbud.SelectedItem != null)
            {
                string lwSelectedItem = lvwSalgsudbud.SelectedItem.ToString();

                foreach (Salgsudbud s in getSalgsudbud())
                {
                    if (lwSelectedItem.Contains(s.SalgsudbudId.ToString()))
                    {
                        endTime = s.tidsfrist;
                        tbMetaltype.Text = s.metaltype;
                        tbMængde.Text = s.mængde + " g";
                    }
                }
                lvwKøbsbud.Items.Clear();
                foreach (Købstilbud k in getKøbstilbud())
                {
                    if (lwSelectedItem.Contains(k.salgsudbudId.ToString()))
                    {
                        lvwKøbsbud.Items.Add(k.pris + " kr. | " + k.Køber.navn + " Tlf.:" + k.Køber.tlf);
                    }
                }
                countdownTimer();
            }
        }
        private DateTime endTime = new DateTime();
        private void countdownTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;

            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan t = endTime - currentTime;
            if (t.Ticks < 0)
            {
                this.Dispatcher.Invoke(() =>
                    {
                        tbTidsfrist.Text = "Auktion lukket.";
                    });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    tbTidsfrist.Text = t.ToString(@"dd\ hh\:mm\:ss");
                }
                );
            }
        }

        private void btnOpretSalgsbud_Click(object sender, RoutedEventArgs e)
        {
            Salgsudbud salgsudbud = new Salgsudbud();
            if (tbCreateMetal.Text.Length != 0 && tbCreateMængde.Text.Length != 0 && tbCreateTidsfrist.Text.Length != 0)
            {
                salgsudbud.metaltype = tbCreateMetal.Text;
                salgsudbud.mængde = decimal.Parse(tbCreateMængde.Text);
                DateTime dt = DateTime.Parse(tbCreateTidsfrist.Text);
                salgsudbud.tidsfrist = dt;

                using (var ctx = new EksamenDatabaseEntities())
                {
                    salgsudbud.SalgsudbudId = ctx.Salgsudbuds.Count() + 1;
                    ctx.Salgsudbuds.Add(salgsudbud);
                    ctx.SaveChanges();
                }
                lvwSalgsudbud.Items.Clear();
                foreach (Salgsudbud s in getSalgsudbud())
                {
                    lvwSalgsudbud.Items.Add(s.SalgsudbudId);
                }
            }
        }
    }
}