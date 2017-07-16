using ExamCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ExamCalculator.Controllers

{
    public class HomeController : Controller
    {

        public static string connetionString = "Data Source=TOSHIBA-NTB;Initial Catalog=StudentInformation; Integrated Security = SSPI";
        SqlConnection cnn = new SqlConnection(connetionString);

        public ActionResult Index()
        {
            CalculateModels model = new CalculateModels();


            return View(model);
        }

        public ActionResult ResultListofPoints()
        {
            cnn.Open();
            //student cedveline insert etmek ucun
            string sorgu4 = "select  * from [dbo].[students] S inner Join points P on S.id = P.student_id";
            SqlCommand command4 = new SqlCommand(sorgu4, cnn);
            DataTable dt = new DataTable();
            dt.Load(command4.ExecuteReader());

            return View(dt);

        }



        public ActionResult Calculate(CalculateModels model)
        {          
                cnn.Open();
                        //student cedveline insert etmek ucun
                        string sorgu = "insert into students (name, surname) values (N'" + model.name + "',N'" + model.surname + "')";
                        SqlDataAdapter adapter = new SqlDataAdapter(sorgu, connetionString);
                        //adapter.SelectCommand = new SqlCommand(sorgu, cnn);
                        SqlCommand command = new SqlCommand(sorgu, cnn); 
                        command.ExecuteNonQuery();



                        //student cedvelinden son studentin Id sini gotururuk. cunki qiymet cedveline o id ile elave edeceyik
                        string sorgu3 = "select max(id) from [dbo].[students] ";
                        SqlDataAdapter adapter3 = new SqlDataAdapter(sorgu3, connetionString);
                        adapter3.SelectCommand = new SqlCommand(sorgu3, cnn);
                        SqlCommand command3 = new SqlCommand(sorgu3, cnn);
                        DataTable dt = new DataTable();
                        dt.Load(command3.ExecuteReader());
                        int userid = Convert.ToInt32(dt.Rows[0][0]);


                       model.average = (model.project + model.visa + model.final) / 3;

                        string sorgu1 = @"insert into points (project_point, mid_term_point,final_point,average_point,student_id)
                                            values ('" + model.project + "','" + model.visa + "','" + model.final + "','" + model.average + "','" + userid + "')";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu1, connetionString);
                        //adapter.SelectCommand = new SqlCommand(sorgu, cnn);
                        SqlCommand command1 = new SqlCommand(sorgu1, cnn);
                        command1.ExecuteNonQuery();


            cnn.Close();

            model.isdataSuccessModel = true;

            return View("~/Views/Home/Index.cshtml", model);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


//namespace ExamCalculator.Models