﻿using Form;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Login_Window.AddUserForm;
using static System.Windows.Forms.LinkLabel;

namespace Login_Window
{
    public partial class Admin : System.Windows.Forms.Form
    {
        string curCourse;
        string tempUser;
        int line_to_edit;
        int itemToRemove;
        public Admin()
        {
            InitializeComponent();
            List<String> Coursedatabase = new List<String>();
            var Courselist = new Dictionary<int, dynamic>();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\CourseDatabase.txt");
            System.Console.WriteLine("Contents of Course database");

            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase.Add(line);
                Console.WriteLine("\n" + line);
            }

            for (int i = 0; i < Coursedatabase.Count; i++)
            {
                listBox2.Items.Add(Coursedatabase[i]);
            }


            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string password = Userstring[1];
                string firstname = Userstring[2];
                string middlename = Userstring[3];
                string lastname = Userstring[4];
                string status = Userstring[5];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Userlist[i] = d1;
                Userlist[i].usrs = "User" + i;
                Console.WriteLine(Userlist[i].usrs);

                Userlist[i].usrs = new { usrname = username, pswd = password, fname = firstname, mname = middlename, lname = lastname, s = status };

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }

            // This is loading in the users into the correct places
            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                if ((Userlist[i].usrs.s == "admin"))
                { listBox1.Items.Add(Userlist[i].usrs.usrname + " " + Userlist[i].usrs.s); }
                else if (Userlist[i].usrs.s == "faculty")
                { listBox3.Items.Add(Userlist[i].usrs.usrname); }//+ " " + Userlist[i].usrs.s); }
                else { listBox4.Items.Add(Userlist[i].usrs.usrname); }

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempUser = listBox1.SelectedItem.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            // *************** SHOULD ADD THE PROFS NAME TO THE ROSTER TOO *********************

            listBox6.Items.Clear();
            curCourse = listBox2.SelectedItem.ToString();

            string courseNum = curCourse.Substring(0, curCourse.IndexOf(' '));
            //string courseName = curCourse.Substring(curCourse.IndexOf(courseNum), curCourse.IndexOf(' '));
            //string profName = "Instructor: " + curCourse.Substring(curCourse.IndexOf(courseName), curCourse.IndexOf(' '));
            listBox6.Items.Add(courseNum); //Prints out the class number to the roster before displaying the students
            //listBox6.Items.Add(profName);

            //string[] OGCourseDataBase = System.IO.File.ReadAllLines(@"C:\Users\katie\OneDrive\Desktop\Databases SE\OrginalCourseHistoryDatabase.txt");
            string[] CourseHisDataBase = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\CourseHistoryDatabase.txt");
            List<string> addedCoursesDataBase = new List<string>();

            foreach (string line in CourseHisDataBase)
            {
                string[] splitLines = line.Split(' ');
                if (splitLines.Contains(courseNum))
                {

                    if (splitLines[Array.IndexOf(splitLines, courseNum) + 1] == "F23")
                    {
                        listBox6.Items.Add(splitLines[0]);
                    }
                    else
                    {
                        string[] splitLines2 = line.Split(courseNum);
                        if (splitLines2.Contains(courseNum))
                        {

                            if (splitLines[Array.IndexOf(splitLines2, courseNum) + 1] == "F23")
                            { listBox6.Items.Add(splitLines[0]); }


                        }
                    }
                }


            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Refresh Button that can be used after deleting a user
            Admin refreshedForm = new Admin();
            refreshedForm.Show();
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Steal Advisee code from faculty menu


        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ask Naomi to do this bit
            tempUser = listBox3.SelectedItem.ToString();
            listBox5.Items.Clear();
            List<String> Userdatabase = new List<String>();
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\UserDatabase.txt");

            foreach (string line in users)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
            }

            for (int i = 0; i < Userdatabase.Count; i++)
            {
                string[] Userstring = Userdatabase[i].Split(" ");
                string advisor = Userstring[5];
                if (tempUser == advisor)
                {
                    string advisee = Userstring[2] + " " + Userstring[3] + " " + Userstring[4];
                    listBox5.Items.Add(advisee);
                }
            }
            //itemToRemove = listBox4.SelectedIndex;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempUser = listBox4.SelectedItem.ToString();
            //itemToRemove = listBox4.SelectedIndex;
            //listBox4.Items.RemoveAt(itemToRemove);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string[] lines = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\UserDatabase.txt");
            List<String> Userdatabase = new List<String>();
            string[] lines3 = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\CourseHistoryDatabase.txt");
            List<String> CourseHistoryDatabase = new List<String>();
            var Userlist = new Dictionary<int, dynamic>();

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
            foreach (string line in lines3)
            {
                // Use a tab to indent each line of the file.
                CourseHistoryDatabase.Add(line);
                Console.WriteLine("\n" + line);

            }

            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string password = Userstring[1];
                string firstname = Userstring[2];
                string middlename = Userstring[3];
                string lastname = Userstring[4];
                string status = Userstring[5];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Userlist[i] = d1;
                Userlist[i].usrs = "User" + i;
                Console.WriteLine(Userlist[i].usrs);

                Userlist[i].usrs = new { usrname = username, pswd = password, fname = firstname, mname = middlename, lname = lastname, s = status };
                if (Userlist[i].usrs.usrname == tempUser)
                {
                    line_to_edit = i;
                }

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }

            using (StreamWriter writer = new StreamWriter(@"C:\Users\turtl\Desktop\UserDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        //writer.WriteLine(""); //skips over the rewrite to delete selected users.
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine]);
                    }
                }
            }
            for (int i = 0; i < CourseHistoryDatabase.Count(); i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username1 = Userstring[0];
                if (username1 == tempUser)
                {
                    line_to_edit = i;
                }

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\turtl\Desktop\CourseHistoryDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= lines.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        //writer.WriteLine(""); //skips over the rewrite to delete selected users.
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine]);
                    }
                }
            }
            listBox4.Items.Clear();
            listBox3.Items.Clear();
            listBox1.Items.Clear();
            Userdatabase.Clear();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\UserDatabase.txt");
            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Userdatabase.Add(line);
                Console.WriteLine("\n" + line);

            }
             for (int i = 0; i < Userdatabase.Count(); i++)
            {
                string[] Userstring = Userdatabase[i].Split(' ');
                string username = Userstring[0];
                string password = Userstring[1];
                string firstname = Userstring[2];
                string middlename = Userstring[3];
                string lastname = Userstring[4];
                string status = Userstring[5];
                dynamic d1 = new System.Dynamic.ExpandoObject();
                Userlist[i] = d1;
                Userlist[i].usrs = "User" + i;
                Console.WriteLine(Userlist[i].usrs);

                Userlist[i].usrs = new { usrname = username, pswd = password, fname = firstname, mname = middlename, lname = lastname, s = status };

                //Console.WriteLine("Key {0}, Username: {1}, Password: {2}, First name: {3}, Middle name: {4}, Last name: {5}, Status {6}\n", Userlist[i].usrs, Userlist[i].usrs.usrname, Userlist[i].usrs.pswd, Userlist[i].usrs.fname, Userlist[i].usrs.mname, Userlist[i].usrs.lname, Userlist[i].usrs.s);
            }

            // This is loading in the users into the correct places
            for (int i = 0; i < Userdatabase.Count(); i++)
            {
                if ((Userlist[i].usrs.s == "admin"))
                { listBox1.Items.Add(Userlist[i].usrs.usrname); }
                else if (Userlist[i].usrs.s == "faculty")
                { listBox3.Items.Add(Userlist[i].usrs.usrname); }//+ " " + Userlist[i].usrs.s); }
                else { listBox4.Items.Add(Userlist[i].usrs.usrname); }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            AddUserForm newUserForm = new AddUserForm();
            newUserForm.Show();
            this.Close();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            Faculty facultyForm = new Faculty("dumFac");
            facultyForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDrop addForm = new AddDrop("dumStu");
            addForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<String> Coursedatabase = new List<String>();
            string[] courses = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\CourseDatabase.txt");
            foreach (string line in courses)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase.Add(line);
                //Console.WriteLine("\n" + line);
            }
            for (int i = 0; i < Coursedatabase.Count(); i++)
            {
                if (curCourse == Coursedatabase[i])
                {
                    line_to_edit = i;
                    string[] tempSplit = Coursedatabase[i].Split(" ");
                    string courseName = tempSplit[0]; 
                    courseDeletionForm deleteForm = new courseDeletionForm(courseName);
                    deleteForm.Show();
                }
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\turtl\Desktop\CourseDatabase.txt"))
            {
                for (int currentLine = 0; currentLine <= courses.Length - 1; ++currentLine) //finds the line in the text file to edit and overwrites it.
                {
                    if (currentLine == line_to_edit)
                    {
                        //writer.WriteLine(""); //skips over the rewrite to delete selected users.
                    }
                    else
                    {
                        writer.WriteLine(courses[currentLine]);
                    }
                }
            }

            listBox2.Items.Clear();
            var Courselist = new Dictionary<int, dynamic>();
            List<String> Coursedatabase2 = new List<String>();
            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\turtl\Desktop\CourseDatabase.txt");
            //System.Console.WriteLine("Contents of Course database");

            foreach (string line in lines2)
            {
                // Use a tab to indent each line of the file.
                Coursedatabase2.Add(line);
                Console.WriteLine("\n" + line);
            }

            for (int i = 0; i < Coursedatabase2.Count; i++)
            {
                listBox2.Items.Add(Coursedatabase2[i]);
            }
        }
    }
}
