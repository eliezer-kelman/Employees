using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public partial class Form1 : Form
    {
        Employee[] employees;
        public Form1()
        {
            InitializeComponent();
        }

        // סטטוס עובד
        private string status
        { get
                // מחזיר את הסטטוס 
            {
                return pStatus.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            }
            set
            {
                // אפשרות לשנות את הסטטוס דרך הקוד 
                foreach (var radio in pStatus.Controls.OfType<RadioButton>())
                {
                    radio.Checked = radio.Text == value;
                };
            }
        }
        // הוספת עובד
        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            // יצירת עובד ע"י הקלאס employee
            Employee newEmployee = new Employee(
                int.Parse(txtCode.Text),
                txtID.Text,
                txtFirstName.Text,
                txtLastName.Text,
                dtpDateOfBirth.Value,
                rdbMale.Checked,
                status,
                txtTelephone.Text,
                txtCelphone.Text,
                txtCity.Text,
                txtStreet.Text,
                txtNumber.Text);
            // מציג את גיל העובד
            txtAge.Text = newEmployee.Age.ToString();
            // מקפיץ הודעה מה הקוד של העובד
            MessageBox.Show(Code.ToString());
            // מוסיף את העובד החדש למערך
            addEmployeeToArray(newEmployee);
        }
        // פונקציה שמוסיפה עובד למערך
        private void addEmployeeToArray(Employee employee)
        {
            // אם זה העובד הראשון הוא פותח מערך עם מקום אחד
            if (employees == null)
            {
                employees = new Employee[1];
            }
            else
            {
                // פותח מערך זמני שגדול מהמערך הקבוע במקום אחד
                Employee[] temp = new Employee[employees.Length +1];
                // מעביר את כל העובדים למערך הזמני
                for (int i = 0; i < employees.Length; i++)
                {
                    temp[i] = employees[i];
                }
                // קובע את המערך הזמני למערך הקבוע
                employees = temp;
            }
            // מוסיף את העובד החדש למערך
            employees[employees.Length - 1] = employee;
        }

        // פונקציה שמשנה את הניסוח לזכר ונקבה
        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            // בלחיצה על נקבה משנה את הניסוח
            if (rdbFemale.Checked)
            {
                rdbSingle.Text = "רווקה";
                rdbMarride.Text = "נשואה";
                rdbDivorce.Text = "גרושה";
                rdbWidow.Text = "אלמנה";
            }
            else
            {
                // בלחיצה על זכר הכפתור נקבה נהיה false ומשתנה חזרה
                rdbSingle.Text = "רווק";
                rdbMarride.Text = "נשוי";
                rdbDivorce.Text = "גרוש";
                rdbWidow.Text = "אלמן";
            }
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
        //    Employee[] temp = new Employee[employees.Length -1];
        //    for (int i = 0; i < employees.Length; i++)
        // השורה הזו צריכה השלמה
        //        if (employees[i] != Employee.id)
        //    {
        //        temp[i] = employees[i];
        //    }
        //    employees = temp;
        }
        // חיפוש עובד לפי קוד עובד
        private void btnSearchWorkerByCode_Click(object sender, EventArgs e)
        {
            int result = 0;
            bool isValid = false;
            // פותח חלון לקבלת מספר
            while (!isValid) 
            {
                // מוודא שקיבל מספר
                isValid = int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("הכנסס קוד עובד", "חיפוש לפי קוד עובד"), out result);
            }
            // שולח את הקוד עובד לחיפוש
            Employee selectedEmployee = searchEmployeeByCode(result);
            // מציג את נתוני העובד על המסך
            showEmployee(selectedEmployee);

        }
        // פונקציה שמציגה את נתוני העובד על המסך
        private void showEmployee (Employee employee)
        {
            // אם העובד לא קיים
            if (employee == null)
            {
                MessageBox.Show("לא נמצא עובד להצגה");
                return;
            }
            else
            {
                txtCode.Text = employee.Code.ToString();
                txtID.Text = employee.ID;
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                dtpDateOfBirth.Value = employee.Birthday;
                txtTelephone.Text = employee.Telephone;
                txtCelphone.Text = employee.Celphone;
                txtCity.Text = employee.City;
                txtStreet.Text = employee.Street;
                txtNumber.Text = employee.Number;
                // אם זה זכר == אמת סמן את זכר
                if (employee.IsMale) { rdbMale.Checked = true; }
                // אם לא, סמן את נקבה
                else { rdbFemale.Checked = true; }
                // שימוש בסט של סטטוס לסימון הסטטוס הרלוונטי
                status = employee.Status;
            }
        }
        // פונקציה לחיפוש עובד לפי קוד
        private Employee searchEmployeeByCode(int code)
        {
            // עובר על המערך עובדים
            for (int i = 0; i < employees.Length; i++)
            {
                // מחפש לפי הקוד
                if (employees[i].Code == code)
                {
                    // מחזיר את העובד
                    return employees[i];
                }
            }
            // אם לא מצא מחזיר נאל
            return null;
        }
        // פונקציה לחיפוש עובד לפי תעודת זהות
        private Employee searchEmployeeByID(string id)
        {
            // עובר על המערך עובים
            for (int i = 0; i < employees.Length; i++)
            {
                // מחפש לפי תעודת זהות
                if (employees[i].ID == id)
                {
                    // מחזיר את העובד
                    return employees[i];
                }
            }
            // אם לא מצא מחזיר נאל
            return null;
        }
        // חיפוש לפי תעודת זהות
        private void btnSearchWorkerByID_Click(object sender, EventArgs e)
        {
            int oneresult = 0;
            bool isValid = false;
            // פותח חלון לקבלת מספר תעודת זהות
            while (!isValid)
            {
                // מוודא שקיבל מספר
                isValid = int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("הכנס תעודת זהות", "חיפוש לפי תעודת זהות"), out oneresult);
            }

            string result = oneresult.ToString();
            // שולח את התעודת זהות לחיפוש
            Employee selectedEmployee = searchEmployeeByID(result);
            // מציג את פרטי העובד על המסך
            showEmployee(selectedEmployee);
        }
        // עובד חדש
        private void btnNewWorker_Click(object sender, EventArgs e)
        {
            // ניקוי הפרטים מהמסך
            clearFields(this)
            // קביעת מספר קוד עובד
            if (employees == null)
            {
                txtCode.Text = "10";
            }
            else
            { 
                txtCode.Text = employees[employees.Length - 1].Code + 1.ToString();
            }
        }
        // פונקציה לניקוי הפרמטרים על המסך
        private void clearFields(Control control)
        {
            // רץ על כל האלמנטים שנמצאים בתוך הקונטרול שקבלנו
            foreach (Control ctr in control.Controls) 
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
                if (ctr is RadioButton)
                {
                    ((RadioButton)ctr).Checked = false;      
                }
                if (ctr is DateTimePicker)
                {
                    ((DateTimePicker)ctr).Value = DateTime.Now;
                } // מנקה פאנל ע"י קריאה לרקורסיה
                if (ctr is Panel)
                {
                    clearFields(ctr);
                }
            }


    }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
