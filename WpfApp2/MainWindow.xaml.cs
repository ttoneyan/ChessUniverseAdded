using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chessuniverse.Library;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _t;
        private int _imgDownX;
        private int _imgDownY;
        private int _imgUpX;
        private int _imgUpY;

        private System.Windows.Point _ptLast = new System.Windows.Point();

        private ChessBoard chessboard = new ChessBoard();

        public MainWindow()
        {
            InitializeComponent();
            chessboard.SetStartPosition();
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (_t)
            {
                var img = (Image)sender;

                var ptNew = new System.Windows.Point();
                ptNew.X = img.Margin.Left;
                ptNew.Y = img.Margin.Top;

                img.Margin = new Thickness(
                    ptNew.X + (e.GetPosition(img).X - _ptLast.X),
                    ptNew.Y + (e.GetPosition(img).Y - _ptLast.Y),
                    0, 0);
            }
        }

        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
            _t = true;

            var img = (Image)sender;

            _ptLast = e.GetPosition(img);

            Mouse.Capture(img);
            Panel.SetZIndex(img, 1);

            _imgDownX = (int)img.Margin.Left;
            _imgDownY = (int)img.Margin.Top;
        }

        public void MouseUp(object sender, MouseButtonEventArgs e)
        {
            _t = false;
            var img = (System.Windows.Controls.Image)sender;

            // Calculate indices based on tile size (57)
            // Clamping to 0-7 prevents the IndexOutOfRangeException that crashes the UI
            int toX = Math.Clamp((int)(img.Margin.Left + 28.5) / 57, 0, 7);
            int toY = Math.Clamp((int)(img.Margin.Top + 28.5) / 57, 0, 7);

            int fromX = _imgDownX / 57;
            int fromY = _imgDownY / 57;

            Mouse.Capture(null);
            Panel.SetZIndex(img, 0);

            Coordinate start = new Coordinate((Letters)fromX, (Numbers)fromY);
            Coordinate end = new Coordinate((Letters)toX, (Numbers)toY);

            if (TryMove(start, end))
            {
                // Success: Snap to the grid
                img.Margin = new Thickness(toX * 57, toY * 57, 0, 0);
            }
            else
            {
                // Failure: Snap back to original position
                img.Margin = new Thickness(_imgDownX, _imgDownY, 0, 0);
            }
            label3.Content = "M " + img.Margin.Left.ToString() + " " + img.Margin.Top.ToString();
        }

        private bool TryMove(Coordinate start, Coordinate end)
        {
            try
            {
                // Row is start.Number, Column is start.Letter
                var piece = chessboard[(int)start.Number, (int)start.Letter];

                if (piece is IMovable movable)
                {
                    if (!movable.Move(start, end, chessboard)) return false;

                    // Update the board array ONLY here
                    chessboard[(int)end.Number, (int)end.Letter] = piece;
                    chessboard[(int)start.Number, (int)start.Letter] = null;
                    return true;
                }
                return false;
            }
            catch
            {
                return false; // Safely ignore crashes to keep UI alive
            }

            
        }
    }

}