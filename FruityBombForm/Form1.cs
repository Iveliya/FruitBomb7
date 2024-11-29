using FruityBomb.Controller;

namespace FruityBombForm
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer[] slotTimers;
        private PictureBox[] slots;
        private readonly Image[] slotImages;
        private Random random;
        private bool isSpinning = false;
        private int[] currentImageIndexes;
        private int[] nextImageIndexes;
        private int[] slideOffsets;
        private bool[] highlightedSlots;
        private string[] finalSymbols;

        private FruityBombController controller;
        private decimal balance = 1000m;
        private decimal currentBet = 2.00m;

        private int[] slotSpeeds;
        private int minSpeed = 2;
        private int maxSpeed = 30;
        private float decelerationFactor = 0.92f;

        public Form1()
        {
            InitializeComponent();
            controller = new FruityBombController();
            slotImages = new Image[]
            {
                Properties.Resources.Leonardo_Phoenix_Create_a_stylized_Bell_symbol_for_a_casino_ga_3_removebg_preview,
                Properties.Resources.Leonardo_Phoenix_create_a_vibrant_stylized_eggplant_symbol_on_3_removebg_preview,
                Properties.Resources.Leonardo_Phoenix_design_a_vibrant_and_stylized_watermelon_slic_0_removebg_preview,
                Properties.Resources.Leonardo_Phoenix_A_stylized_vibrant_cherry_symbol_isolated_on_1_removebg_preview
            };

            random = new Random();
            slots = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5 };

            slotTimers = new System.Windows.Forms.Timer[slots.Length];
            currentImageIndexes = new int[slots.Length];
            nextImageIndexes = new int[slots.Length];
            slideOffsets = new int[slots.Length];
            slotSpeeds = new int[slots.Length];
            highlightedSlots = new bool[slots.Length];
            finalSymbols = new string[slots.Length];

            for (int i = 0; i < slots.Length; i++)
            {
                slotTimers[i] = new System.Windows.Forms.Timer();
                slotTimers[i].Interval = 16;
                int slotIndex = i;
                slotTimers[i].Tick += (sender, e) => AnimateSlot(slotIndex);
                slots[i].Paint += (sender, e) => DrawSlot(sender, e, slotIndex);
                currentImageIndexes[i] = random.Next(slotImages.Length);
                nextImageIndexes[i] = (currentImageIndexes[i] + 1) % slotImages.Length;
                slotSpeeds[i] = maxSpeed;
                highlightedSlots[i] = false; 
            }

            UpdateUI();
        }
        private void AnimateSlot(int slotIndex)
        {
            slideOffsets[slotIndex] += slotSpeeds[slotIndex];
            if (slideOffsets[slotIndex] >= slots[slotIndex].Height)
            {
                slideOffsets[slotIndex] = 0;
                currentImageIndexes[slotIndex] = nextImageIndexes[slotIndex];
                nextImageIndexes[slotIndex] = random.Next(slotImages.Length);
            }

            slots[slotIndex].Invalidate();
        }


        private void DrawSlot(object sender, PaintEventArgs e, int slotIndex)
        {
            var g = e.Graphics;
            int height = slots[slotIndex].Height;
            g.DrawImage(slotImages[currentImageIndexes[slotIndex]], new Rectangle(0, -slideOffsets[slotIndex], slots[slotIndex].Width, height));
            g.DrawImage(slotImages[nextImageIndexes[slotIndex]], new Rectangle(0, height - slideOffsets[slotIndex], slots[slotIndex].Width, height));
            if (highlightedSlots[slotIndex])
            {
                using (var highlightBrush = new SolidBrush(Color.FromArgb(128, Color.Gold)))
                {
                    g.FillRectangle(highlightBrush, new Rectangle(0, 0, slots[slotIndex].Width, slots[slotIndex].Height));
                }
            }
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            StartSpin();
        }

        private async void StartSpin()
        {
            if (isSpinning || balance < currentBet)
            {
                MessageBox.Show("Insufficient balance or already spinning!");
                return;
            }

            isSpinning = true;
            button1.Enabled = false;

            balance -= currentBet;
            UpdateUI();
            Array.Fill(highlightedSlots, false);


            for (int i = 0; i < slots.Length; i++)
            {
                currentImageIndexes[i] = random.Next(slotImages.Length);
                nextImageIndexes[i] = random.Next(slotImages.Length);
                slideOffsets[i] = 0;
            }

  
            foreach (var timer in slotTimers)
            {
                timer.Start();
            }

  
            await Task.Delay(2000);
            for (int i = 0; i < slots.Length; i++)
            {
                await Task.Delay(500);
                slotTimers[i].Stop();


                slideOffsets[i] = 0;
                finalSymbols[i] = GetSymbolNameFromIndex(currentImageIndexes[i]);
                slots[i].Invalidate();
            }
            Dictionary<string, int> winningCombination = controller.Combination(2, finalSymbols[0], finalSymbols[1], finalSymbols[2], finalSymbols[3]);
            decimal payout = controller.PayOut(2, currentBet);

            if (winningCombination.Count > 0)
            {
                HighlightWinningSymbols(finalSymbols, winningCombination.Keys.ToList());
                label2.Text = $"${payout:F2}";
            }
            balance += payout;
            UpdateUI();

            isSpinning = false;
            button1.Enabled = true;
        }




        private void HighlightWinningSymbols(string[] slotSymbols, List<string> winningSymbols)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                highlightedSlots[i] = winningSymbols.Contains(slotSymbols[i]);
                slots[i].Invalidate(); 
            }
        }

        private string GetSymbolNameFromIndex(int index)
        {
            string[] symbolNames = { "Bell", "Eggplant", "Watermelon", "Cherry" };
            return symbolNames[index];
        }

        private void UpdateUI()
        {
            label3.Text = $"Balance: ${balance:F2}";
            button1.Enabled = !isSpinning;
            button1.Text = isSpinning ? "Spin" : $"Spin (${currentBet:F2})";

        }


        private void SetBet(decimal betAmount)
        {
            currentBet = betAmount;
            UpdateUI();
            StartSpin();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var timer in slotTimers)
            {
                timer.Stop();
                timer.Dispose();
            }
            base.OnFormClosing(e);
        }
        private void pictureBox4_Click(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void pictureBox3_Click(object sender, EventArgs e) { }

        private void pictureBox5_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            SetBet(2.00m);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetBet(5.00m);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetBet(10.00m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetBet(50.00m);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
