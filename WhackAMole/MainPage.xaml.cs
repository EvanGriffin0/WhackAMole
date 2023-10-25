namespace WhackAMole;

public partial class MainPage : ContentPage
{
    private Random random;
    private int score = 0;
    private int countdown = 5;
    private System.Timers.Timer timer;
    private int interval = 1000;

    public MainPage()
    {
        InitializeComponent();
        random = new Random();
        SetUpTimers();
    }

    private void SetUpTimers()
    {
        /*Dispatcher.StartTimer(TimeSpan.FromMilliseconds(1000),
            () =>
            {
                TimerFunction();
                return true;
            }
            );
        */
        timer = new System.Timers.Timer
        {
            Interval = interval
        };
        timer.Elapsed += Timer_Elapsed;
    }

    private void Timer_Elapsed(object sender, EventArgs e)
    {
        Dispatcher.Dispatch(
            () =>
            {
                TimerFunction();
            }
            );
    }

    private void TimerFunction()
    {
        if (countdown != 0)
        {
            --countdown;
            timer_lbl.Text = countdown.ToString();
        }
        else
        {
            timer.Stop();
        }
    }

    private void MovetheMole()
    {
        int r, c;
        r = random.Next(3);
        c = random.Next(0, 3);
        smileyimg.SetValue(Grid.RowProperty, r);
        smileyimg.SetValue(Grid.ColumnProperty, c);
        smileyimg.IsVisible = true;
    }

    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        MovetheMole();
        timer.Start();
    }

    private void SwitchBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void ImageTapped(object sender, EventArgs e)
    {
        IncreaseScore();
        MovetheMole();
    }

    private void IncreaseScore()
    {
        score += 10;
        score_lbl.Text = score.ToString();
    }
}
