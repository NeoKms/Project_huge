using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Project_Alpha
{
    class Genetic_Algorithm
    {
        //konst
        public int ID_FACTORY { get; private set; }=-1;
        private MySqlConnection CON_BD=null;
        private string[] name_of_GR_stank= new string[]{"Точильные","Сверлильные","Для сварки","Режущие","Борты", "Днища", "Палубы", "Обшивки", "Кили", "Ячейки", "Корпуса" };//4
        private List<List<int>> col_stank_in_GR = new List<List<int>>();
        private string[] name_of_stank = new string[] { "1й", "2й", "3й", "4й", "5й", "6й", "7й", "8й", "9й", "10й", "11й", "12й", "13й", "14й", "15й", "16й" };//16
        private string[,] detal_names_time_type_on_id = new string[,] { 
        {"1",   "Болт 1",            "10",   "1",    "0" }, 
        {"2",   "Болт 2",            "1",    "1" ,   "0" }, 
        {"3",   "Лист 1",            "40",   "1",    "3" }, 
        {"4",   "Лист 2",            "5",    "1",    "3" }, 
        {"5",   "Шпангоут 1",        "30",   "1",    "2" },
        {"6",   "Шпангоут 2",        "11",   "1",    "2" },
        {"7",   "Шпангоут 3",        "70",   "1",    "2" },
        {"8",   "Бимс 1",            "10",   "1",    "2" },
        {"9",   "Бимс 2",            "70",   "1",    "2" },
        {"10",  "Бимс 3",            "33",   "1",    "2" },
        {"11",  "Ахтерштевень 1",    "50",   "1",    "1" },
        {"12",  "Полубимс 1",        "42",   "1",    "2" },
        {"13",  "Ватервей 1",        "15",   "1",    "3" },

        {"14",  "Днище 1",           "5",   "2",    "5" },
        {"15",  "Борт 1",            "6",   "2",    "4" },
        {"16",  "Палуба 1",          "7",   "2",    "6" },
        {"17",  "Киль 1",            "8",   "2",    "8" },
        {"18",  "Обшивка 1",         "9",   "2",    "7" },
        {"19",  "Днище 2",           "1",   "2",    "5" },
        {"20",  "Борт 2",            "2",   "2",    "4" },
        {"21",  "Палуба 2",          "3",   "2",    "6" },
        {"22",  "Киль 2",            "4",   "2",    "8" },
        {"23",  "Обшивка 2",         "5",   "2",    "7" },
        {"24",  "Борт 3",            "6",   "2",    "4" },
        {"25",  "Палуба 3",          "7",   "2",    "6" },
        {"26",  "Киль 3",            "8",   "2",    "8" },
        {"27",  "Днище 3",           "9",   "2",    "5" },
        {"28",  "Обшивка 3",         "1",   "2",    "7" },

        {"29",  "Ячейка 1",          "2",   "3",    "9" },
        {"30",  "Ячейка 2",          "3",   "3",    "9" },
        {"31",  "Ячейка 3",          "4",   "3",    "9" },

        {"32",  "Корпус Баклера",    "5",   "4",    "10" }};
        private List<int> col_detal_on_types = new List<int> { 13, 15, 3, 1 };
        private int[] res_in_stock_on_id = new int[] { 2,5,0,0,8,3,0,0,1,0,1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        private int[,] cost_res_on_detal = new int[,] {
        {12,13,4,16,4,   0,3,1,1,3,     0,2,1,0,3,      0,0,0,   0},
        {5,5,3,0,0,      5,5,3,0,0,     5,5,3,0,0,      0,0,0,   0},
        {0,0,0,0,8,      0,0,0,0,10,    0,0,0,0,15,     0,0,0,   0},
        {3,3,4,0,0,      0,3,6,1,0,     1,3,2,1,0,      0,0,0,   0},
        {4,0,0,3,0,      4,0,0,3,0,     4,0,0,3,0,      0,0,0,   0},
        {0,4,0,3,0,      1,4,0,3,0,     1,4,0,3,0,      0,0,0,   0},
        {0,0,0,4,3,      0,1,0,3,0,     0,4,0,0,7,      0,0,0,   0},
        {0,5,0,0,0,      0,2,0,4,0,     0,5,0,1,1,      0,0,0,   0},
        {3,3,0,0,0,      3,0,1,0,1,     0,1,3,3,1,      0,0,0,   0},
        {7,0,5,0,0,      0,0,0,0,0,     1,0,6,0,3,      0,0,0,   0},
        {0,0,0,0,0,      1,1,1,1,1,     0,0,0,0,0,      0,0,0,   0},
        {2,2,0,4,0,      0,4,0,2,1,     1,0,1,2,1,      0,0,0,   0},
        {2,0,0,0,0,      2,0,0,0,0,     2,0,0,0,0,      0,0,0,   0},

        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      1,0,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      1,0,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      1,0,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      1,0,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      1,0,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,1,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,1,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,1,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,1,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,1,0,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,1,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,1,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,1,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,1,   0},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,1,   0},

        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,0,   4},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,0,   1},
        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,0,   1},

        {0,0,0,0,0,      0,0,0,0,0,     0,0,0,0,0,      0,0,0,   0}};

        public Genetic_Algorithm(int id_fac)
        {
            ID_FACTORY = id_fac;
            CON_BD = new MySqlConnection("server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root");
        }
        public Genetic_Algorithm()
        {
            col_stank_in_GR.Add(new List<int> { 0, 1, });
            col_stank_in_GR.Add(new List<int> {2, 3, 4, 5, 6,7});
            col_stank_in_GR.Add(new List<int> { 8, 9, 10, 11, 12 });
            col_stank_in_GR.Add(new List<int> { 13, 14, 15 });
        }
        public Individ crossengover(Individ A1, Individ A2)
        {
            List<List<int>> body_1 = A1.get_body(), body_2 = A2.get_body();
            for (int i=0; i < body_1.Count; i++)
            {
                List<int> yach_1 = body_1[i], yach_2 = body_2[i];
                Random rand = new Random();
                int point = rand.Next(1, yach_1.Count-1);

            }
            return A1;
        }
        private Individ[] ALL_POPULATION;
        public Individ[] Create_population(int col)
        {
            Individ[] Arr_individs = new Individ[col];
            for (int i = 0; i < col; i++)
            {
                Arr_individs[i] = new Individ(Get_cell_for_create());
                get_Function(Arr_individs[i].get_body());
            }
            ALL_POPULATION = Arr_individs;
            double pop_fun = get_Function_pop(ALL_POPULATION);
            for (int i = 0; i < ALL_POPULATION.Length; i++)
                ALL_POPULATION[i].Pver = get_Function(ALL_POPULATION[i].get_body()) / pop_fun;
            return Arr_individs;
        }// создает популяцию в количестве col
        public void get_text(RichTextBox el)
        {
            for (int i = 0; i < ALL_POPULATION.Length; i++)
            {
                el.AppendText("Func " + (i + 1) + " = " + get_Function(ALL_POPULATION[i].get_body()) + " ver = " + ALL_POPULATION[i].Pver + "\n");
            }
        }
        public int get_Function(List<List<int>> A)
        {
            return raspred_work(A).Max();
        }//возвращает значение ЦФ особи
        private double get_Function_pop(Individ[] A)
        {
            double result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result+=raspred_work(A[i].get_body()).Max();
            }
            return result;
        }//возвращает значение ЦФ популяции
        private List<int> raspred_work(List<List<int>> A)
        {
            List<List<int>> jobs_in_stank = new List<List<int>>();
            for (int i = 0; i < name_of_stank.Length; i++) jobs_in_stank.Add(new List<int>());
            List<int> result = new List<int>();
            foreach (List<int> yacheika in A)
            {
                foreach (int ID_job in yacheika)
                {
                     int type_job_now=Convert.ToInt32(detal_names_time_type_on_id[ID_job, 4]);
                     int ID_min_stank = 0,_min_=999999;

                     foreach (int ID_stank in col_stank_in_GR[type_job_now])
                    {
                      //  MessageBox.Show(ID_stank+""); 
                        int now_time_stank= get_time_stank(jobs_in_stank[ID_stank]);
                         if (now_time_stank < _min_)
                         {
                             _min_ = now_time_stank;
                             ID_min_stank = ID_stank;
                         }
                    }
                    jobs_in_stank[ID_min_stank].Add(ID_job);
                     
                }
            }
            string red = "";
            for (int i = 0; i < name_of_stank.Length; i++) { result.Add(get_time_stank(jobs_in_stank[i]));red += get_time_stank(jobs_in_stank[i]) + "  "; }
           // MessageBox.Show(red);
            return result;
        }//определяет порядок работ на станках. Возвращает суммарное время работы станков
        private int get_time_stank(List<int> Element)
        {
            int result = 0;
            if (Element.Count!=0)
            foreach(int Id_detal in Element)
            {
                result += Convert.ToInt32(detal_names_time_type_on_id[Id_detal, 2]);
            }
            return result;
        }//определяет суммарное время текущего станка
        public List<List<int>> Get_cell_for_create()
        {
            List<List<int>> result =new List<List<int>>();
            List<int> col_cells= Get_col_cells();
            int sum_cells = 0;
            foreach (int el in col_cells)
            {
                sum_cells += el;
            }
            for (int i=0;i< col_cells.Count; i++)
            {

                List<int> jobs_for_cell = new List<int>();
                int ID_cell_now = col_detal_on_types[1] + i;
                List<int> id_detal_for_cell = new List<int>();

                for (int j = col_detal_on_types[0]; j < col_detal_on_types[0] + col_detal_on_types[1]; j++) 
                {
                    if (cost_res_on_detal[j, ID_cell_now] == 1) id_detal_for_cell.Add(j);
                }
                foreach (int ID_detal in id_detal_for_cell)
                {
                    int j = ID_detal - col_detal_on_types[0];
                        for (int ID_i=0;ID_i< col_detal_on_types[0]; ID_i++)
                        {
                            int col_det = cost_res_on_detal[ID_i, j];
                        for (int k = 0; k < col_det; k++) jobs_for_cell.Add(ID_i);
                        }
                }
                for (int j = 0; j < col_cells[i]; j++)
                    result.Add(jobs_for_cell);
            }
            return result;
        }//получает тело начальной особи
        private List<int> Get_col_cells()
        {
            List<int> result=new List<int>();
            int id_cells = col_detal_on_types[0] + col_detal_on_types[1],
            id_ship = col_detal_on_types[1] + col_detal_on_types[2];
            for (int i = id_cells; i < id_cells+col_detal_on_types[2]; i++)
            {
                result.Add(cost_res_on_detal[i, id_ship]);
            }
            return result;
        }//получает общее кол-во ячеек для производства
        public class Individ
        {
            //констатны
            public double Pver = 0.0;
            private List<List<int>> A; //Тело особи
            public List<List<int>> get_body()
            {
                return A;
            }
            public Individ(List<List<int>> Z)
            {

                A = new List<List<int>>();
                A.AddRange(Z);
                //  A= Z.ToList();
                for (int j = 0; j < 20; j++)
                {
                    for (int i = 0; i < A.Count; i++)
                    {
                        List<int> element = A[i];
                        A[i] = do_rand(element);
                    }// случайно распределяет работы в строке
                }
            }//  Z - перечень работ для создания i ячейки
            private List<int> do_rand(List<int> element)
            {
                Random rand = new Random();
                for (int i = element.Count - 1; i >= 1; i--)
                {
                    int j = rand.Next(i + 1);
                    // обменять значения data[j] и data[i]
                    var temp = element[j];
                    element[j] = element[i];
                    element[i] = temp;
                }
                return element;
            }// случайно распределяет работы в строке
        }//класс создания особи
    }
}
