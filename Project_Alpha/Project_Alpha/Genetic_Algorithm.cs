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
        private string[] name_of_stank = new string[] { "Точильный", "Точильный", "Сверлильный", "Сверлильный", "Сверлильный", "Сверлильный", "Сверлильный", "Сверлильный", "Сварочный", "Сварочный", "Сварочный", "Сварочный", "Сварочный", "Режущий", "Режущий", "Режущий" };//16
        private string[,] detal_names_time_type_on_id = new string[,] { 
        {"1",   "Болт тип 1",            "10",   "1",    "0" }, 
        {"2",   "Болт тип 2",            "1",    "1" ,   "0" }, 
        {"3",   "Лист тип 1",            "40",   "1",    "3" }, 
        {"4",   "Лист тип 2",            "5",    "1",    "3" }, 
        {"5",   "Шпангоут тип 1",        "30",   "1",    "2" },
        {"6",   "Шпангоут тип 2",        "11",   "1",    "2" },
        {"7",   "Шпангоут тип 3",        "70",   "1",    "2" },
        {"8",   "Бимс тип 1",            "10",   "1",    "2" },
        {"9",   "Бимс тип 2",            "70",   "1",    "2" },
        {"10",  "Бимс тип 3",            "33",   "1",    "2" },
        {"11",  "Ахтерштевень тип 1",    "50",   "1",    "1" },
        {"12",  "Полубимс тип 1",        "42",   "1",    "2" },
        {"13",  "Ватервей тип 1",        "15",   "1",    "3" },

        {"14",  "Днище тип 1",           "5",   "2",    "5" },
        {"15",  "Борт тип 1",            "6",   "2",    "4" },
        {"16",  "Палуба тип 1",          "7",   "2",    "6" },
        {"17",  "Киль тип 1",            "8",   "2",    "8" },
        {"18",  "Обшивка тип 1",         "9",   "2",    "7" },
        {"19",  "Днище тип 2",           "1",   "2",    "5" },
        {"20",  "Борт тип 2",            "2",   "2",    "4" },
        {"21",  "Палуба тип 2",          "3",   "2",    "6" },
        {"22",  "Киль тип 2",            "4",   "2",    "8" },
        {"23",  "Обшивка тип 2",         "5",   "2",    "7" },
        {"24",  "Борт тип 3",            "6",   "2",    "4" },
        {"25",  "Палуба тип 3",          "7",   "2",    "6" },
        {"26",  "Киль тип 3",            "8",   "2",    "8" },
        {"27",  "Днище тип 3",           "9",   "2",    "5" },
        {"28",  "Обшивка тип 3",         "1",   "2",    "7" },

        {"29",  "Ячейка тип 1",          "2",   "3",    "9" },
        {"30",  "Ячейка тип 2",          "3",   "3",    "9" },
        {"31",  "Ячейка тип 3",          "4",   "3",    "9" },

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
        private List<Individ> NOW_POPULATION;
        private int col_population = 0;
        private const double _PERSENTV_ = 0.3, _PERSENTN_ = 0.2;
        //

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
        public void text_jobs_in_stank(Individ A, RichTextBox el)
        {
            el.Clear();
            List<List<int>> job_n_st = raspred_work(A.get_body(), 0);
            for (int i = 0; i < job_n_st.Count; i++)
            {
                List<int> element = job_n_st[i];
                el.AppendText("Станок - " + name_of_stank[i]+"\n");
                for (int j=0;j<element.Count;j++)
                {
                el.AppendText("Работа №"+(j+1)+" - "+ detal_names_time_type_on_id[element[j],1] + "\n");
                }
                el.AppendText("Суммарное время работы станка: " + get_time_stank(element)+ "\n\n");
            }
        }//выводит в текстовый блок работы на станках
        public Individ start_gen_alg(int col_popul, int max_iter, RichTextBox el)
        {
            Create_population(col_popul);
            text_func_popul(el, 0);
            int MIN_func = get_Function(NOW_POPULATION[0].get_body()),
                count_max = 0;
            
            for (int i = 0; i < max_iter; i++)
            {
                selection_individ();
                if (get_Function(NOW_POPULATION[0].get_body()) < MIN_func)
                {
                    MIN_func = get_Function(NOW_POPULATION[0].get_body());
                    count_max = 0;
                }
                if (get_Function(NOW_POPULATION[0].get_body()) == MIN_func) count_max++;
                if (count_max > 10) break;
                text_func_popul(el, i+1);
            }
            el.AppendText("\nРабота закончена. Минимальная функция = " + MIN_func);
            return NOW_POPULATION[0];
        }
        private List<Individ> selection_individ()
        {
            Individ[] cross = new Individ[2];
            List<Individ> result = new List<Individ>();
            List<Individ> VERH = new List<Individ>();
            List<Individ> NIZ = new List<Individ>();
            int col_VERH = Convert.ToInt32(col_population * _PERSENTV_), col_NIZ=Convert.ToInt32(col_population * _PERSENTN_);
            for (int i = 0; i < col_VERH; i++)
                VERH.Add(NOW_POPULATION[i]);
            for (int i = (NOW_POPULATION.Count-1); i >= NOW_POPULATION.Count- col_NIZ; i--)
                NIZ.Add(NOW_POPULATION[i]);
            result.Add(VERH[0]);
            for (int i = 0; i < VERH.Count-1; i++)
            {
                for (int j = i + 1; j < VERH.Count; j++)
                {
                    cross = crossengover(VERH[i], VERH[j]);
                    result.Add(cross[0]);
                    result.Add(cross[1]);
                }
                //MessageBox.Show("r1=" + get_Function(VERH[0].get_body()) + "  r2=" + get_Function(VERH[1].get_body()) + "\n ch1=" + get_Function(result[0].get_body()) + "   ch2=" + get_Function(result[1].get_body()));
            }
            for (int i = 0; i < NIZ.Count - 1; i++)
            {
                for (int j = i + 1; j < NIZ.Count; j++)
                {
                    cross = crossengover(NIZ[i], NIZ[j]);
                    result.Add(cross[0]);
                    result.Add(cross[1]);
                }
                //MessageBox.Show("r1=" + get_Function(VERH[0].get_body()) + "  r2=" + get_Function(VERH[1].get_body()) + "\n ch1=" + get_Function(result[0].get_body()) + "   ch2=" + get_Function(result[1].get_body()));
            }
            for (int i = 1; i < VERH.Count; i++)
            {
                if (result.Count >= col_population) break;
                result.Add(VERH[i]);
            }
            for (int i = 0; i < NIZ.Count; i++)
            {
                if (result.Count >= col_population) break;
                result.Add(NIZ[i]);
            }
            if (result.Count > col_population)
            {
                int col_del = result.Count - col_population;
                
                for (int i = result.Count-1; i >= col_population; i--)
                    result.RemoveAt(i);
            }
            //MessageBox.Show(result.Count + "");
            NOW_POPULATION = result;
            Pver_n_sort();
            return result;
        }// создает новую популяцию из текущей
        private Individ[] crossengover(Individ A1, Individ A2)
        {
            List<List<int>> body_1 = new List<List<int>>(A1.get_body()), 
                            body_2 = new List<List<int>>(A2.get_body()),
                            body_3 = new List<List<int>>(),
                            body_4 = new List<List<int>>();
            Individ[] result = new Individ[2];
            for (int ID_yach = 0; ID_yach < body_1.Count; ID_yach++)
            {
                List<int> yach_1 = body_1[ID_yach],
                          yach_2 = body_2[ID_yach],
                          yach_3 = new List<int>(),
                          yach_4 = new List<int>();
                List<int[]> col_n_types_1 = get_col_n_types_jobs(yach_1);
                List<int[]> col_n_types_2 = get_col_n_types_jobs(yach_2);
                //порядок вперед для 1 ребенка
                for (int id_job = 0; id_job < yach_1.Count; id_job++)
                {
                    for (int i = 0; i < col_n_types_1.Count; i++)
                    {
                        int[] elem = col_n_types_1[i];
                        if (elem[0] == yach_1[id_job])
                        {
                            if (elem[1] != 0)
                            {
                                elem[1]--;
                                yach_3.Add(yach_1[id_job]);
                                col_n_types_1[i] = elem;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < col_n_types_1.Count; i++)
                    {
                        int[] elem = col_n_types_1[i];
                        if (elem[0] == yach_2[id_job])
                        {
                            if (elem[1] != 0)
                            {
                                elem[1]--;
                                yach_3.Add(yach_2[id_job]);
                                break;
                            }
                        }
                    }

                }
                for (int i = 0; i < col_n_types_1.Count; i++)
                {
                    int[] elem = col_n_types_1[i];
                    for (int j = 0; j < elem[1]; j++)
                        yach_3.Add(elem[0]);
                }
                // обратный порядок для 2 ребенка
                for (int id_job = yach_1.Count - 1; id_job >= 0; id_job--)
                {
                    //MessageBox.Show(yach_1[id_job] + "");
                    for (int i = 0; i < col_n_types_2.Count; i++)
                    {
                        int[] elem = col_n_types_2[i];
                        if (elem[0] == yach_1[id_job])
                        {
                            if (elem[1] != 0)
                            {
                                elem[1]--;
                                yach_4.Add(yach_1[id_job]);
                                col_n_types_2[i] = elem;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < col_n_types_2.Count; i++)
                    {
                        int[] elem = col_n_types_2[i];
                        if (elem[0] == yach_2[id_job])
                        {
                            if (elem[1] != 0)
                            {
                                elem[1]--;
                                yach_4.Add(yach_2[id_job]);
                                break;
                            }
                        }
                    }

                }
                for (int i = 0; i < col_n_types_2.Count; i++)
                {
                    int[] elem = col_n_types_2[i];
                    for (int j = 0; j < elem[1]; j++)
                        yach_4.Add(elem[0]);
                }
                //MessageBox.Show(yach_4.Count +"");
                body_3.Add(yach_3);
                body_4.Add(yach_4);
                /*string red = "";
                foreach (int[] el in col_n_types)
                {
                    red += el[0] + " " + el[1] + "\n";
                }
                MessageBox.Show(red);*/
            }
            result[0] = new Individ(body_3, false);
            get_Function(result[0].get_body());
            result[1] = new Individ(body_4, false);
            get_Function(result[1].get_body());
            return result;
        }// скрещивание двух особей
        private List<int[]> get_col_n_types_jobs(List<int> yach)
        {
            List<int[]> result = new List<int[]>();
           
            foreach (int element in yach)
            {
                if (result.Count==0)
                    result.Add(new int[] { element, 1 });
                else
                {
                    bool fl = true;
                    for (int i=0;i<result.Count;i++)
                    {
                        int[] elem = result[i];
                        if (element == elem[0])
                        {
                            fl = false;
                            elem[1]++;
                            result[i] = elem;
                            break;
                        }
                    }
                    if (fl == true)
                        result.Add(new int[] { element, 1 });
                }

            }
            return result;
        }//получает количество работ каждого типа в текущей ячейки
        private List<Individ> sort_popul(List<Individ> A)
        {
            Individ temp;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    if (A[i].Pver > A[j].Pver)
                    {
                        temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                }
            }
            return A;
        }// сортирует популяцию по качеству
        public  List<Individ> Create_population(int col)
        {
            col_population = col;
            List<Individ> Arr_individs = new List<Individ>();
            for (int i = 0; i < col_population; i++)
            {
                Arr_individs.Add(new Individ(Get_cell_for_create()));
                get_Function(Arr_individs[i].get_body());
            }
            NOW_POPULATION = Arr_individs;
            Pver_n_sort();
            return Arr_individs;
        }// создает популяцию в количестве col
        private void Pver_n_sort()
        {
            double pop_fun = get_Function_pop(NOW_POPULATION);
            for (int i = 0; i < NOW_POPULATION.Count; i++)
                NOW_POPULATION[i].Pver = get_Function(NOW_POPULATION[i].get_body()) / pop_fun;
            NOW_POPULATION = sort_popul(NOW_POPULATION);
        }// вычисляет качество и сортирует по качеству
        private void text_func_popul(RichTextBox el,int num)
        {
            el.AppendText("Популяция №" + num + "\n");
            for (int i = 0; i < NOW_POPULATION.Count; i++)
            {
                el.AppendText("Особь №" + (i + 1) + ". Функция=" + get_Function(NOW_POPULATION[i].get_body()) + "; Качество=" + NOW_POPULATION[i].Pver + "\n");
            }
        }//определяет сумму ЦФ всей популяции
        private int get_Function(List<List<int>> A)
        {
            return raspred_work(A).Max();
        }//возвращает значение ЦФ особи
        private double get_Function_pop(List<Individ> A)
        {
            double result = 0;
            foreach (Individ el in A)
            { 
                result+=raspred_work(el.get_body()).Max();
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
        private List<List<int>> raspred_work(List<List<int>> A,int ei)
        {
            List<List<int>> jobs_in_stank = new List<List<int>>();
            for (int i = 0; i < name_of_stank.Length; i++) jobs_in_stank.Add(new List<int>());
            List<int> result = new List<int>();
            foreach (List<int> yacheika in A)
            {
                foreach (int ID_job in yacheika)
                {
                    int type_job_now = Convert.ToInt32(detal_names_time_type_on_id[ID_job, 4]);
                    int ID_min_stank = 0, _min_ = 999999;

                    foreach (int ID_stank in col_stank_in_GR[type_job_now])
                    {
                        //  MessageBox.Show(ID_stank+""); 
                        int now_time_stank = get_time_stank(jobs_in_stank[ID_stank]);
                        if (now_time_stank < _min_)
                        {
                            _min_ = now_time_stank;
                            ID_min_stank = ID_stank;
                        }
                    }
                    jobs_in_stank[ID_min_stank].Add(ID_job);

                }
            }
            return jobs_in_stank;
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
        private List<List<int>> Get_cell_for_create()
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
            }//возвращает тело особи
            public Individ(List<List<int>> Z,bool fl=true)
            {

                A = new List<List<int>>();
                A.AddRange(Z);
                if (fl)
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
