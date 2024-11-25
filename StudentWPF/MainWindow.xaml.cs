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

namespace StudentWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private List<Student> students = new List<Student>();
		public MainWindow()
        {
            InitializeComponent();
            LoadStudentData();
        }

        private void LoadStudentData()
        {


            students.Add(new Student() { StudentId = 1, FirstName = "John", LastName = "Smith", Address = "123 Dobberman St. Lewisville, KS", MonthOfAdmission = "Mar", Grade = 'B' });
            students.Add(new Student() { StudentId = 2, FirstName = "Kevin", LastName = "Ortiz", Address = "523 Rocksford Ave. Boston MA", MonthOfAdmission = "May", Grade = 'C' });
            students.Add(new Student() { StudentId = 3, FirstName = "Hannah", LastName = "Kate", Address = "1278 N Winslow Dr, Farmersville TX", MonthOfAdmission = "Sep", Grade = 'A' });
			
            StudentData.ItemsSource = students;
        }
		private void AddStudentButton_Click(object sender, RoutedEventArgs e)
		{
			var newStudent = new Student
			{
				StudentId = students.Count + 1,
                FirstName = "New", 
                LastName = "Student", 
                Address = "Unknown", 
                MonthOfAdmission = "Unknown", 
                Grade = 'N' 
            }; 
            students.Add(newStudent);
			RefreshStudentDataGrid();
		} 
        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e) 
        { 
            if (StudentData.SelectedItem != null) 
            { 
                var selectedStudent = (Student)StudentData.SelectedItem; 
                students.Remove(selectedStudent);
				RefreshStudentDataGrid();
			} 
            else 
            { 
                MessageBox.Show("No student selected to remove."); 
            } 
        }
		private void RefreshStudentDataGrid() 
        { 
            StudentData.ItemsSource = null; 
            StudentData.ItemsSource = students; 
        }

	}
}