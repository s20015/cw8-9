using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)

            Console.WriteLine("Przykład 1 query:");

            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select emp;
            foreach(var e in res)
            {
                Console.WriteLine(e);
            }


            Console.WriteLine("Przykład 1 lambda:");

            //2. Lambda and Extension methods
            var res2 = Emps.Where(e => e.Job == "Backend programmer").ToList();
            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            Console.WriteLine("Przykład 2 query :");

            var res = from emp in Emps
                      where emp.Job == "Frontend programmer" && emp.Salary > 1000
                      orderby emp.Ename descending
                      select emp;

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Przykład 2 lambda:");


            var res2 = Emps.Where(e => e.Job == "Frontend programmer")
                .Where(e => e.Salary > 1000)
                .OrderByDescending(e => e.Ename).ToList();
            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }


        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            Console.WriteLine("Przykład 3 query:");
            var res = (from emp in Emps
                       orderby emp.Salary descending
                       select emp.Salary).First();

            Console.WriteLine(res);

            Console.WriteLine("Przykład 3 lambda:");

            var res2 = Emps.Max(e => e.Salary);

            Console.WriteLine(res2);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            Console.WriteLine("Przykład 4 query:");

            var res = (from emp in Emps
                       where emp.Salary == (from emp1 in Emps
                                            orderby emp1.Salary descending
                                            select emp1.Salary).First()
                       select emp);

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Przykład 4 lambda:");

            var res2 = Emps.Where(e => e.Salary == Emps.Select(e => e.Salary).Max());
            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            Console.WriteLine("Przykład 5 query :");
            var res = from emp in Emps
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Praca = emp.Job

                      };
            foreach (var e in res)
            {
                Console.WriteLine(e);
            }


            Console.WriteLine("Przykład 5 lambda :");

            var res2 = Emps.Select(e => new
            {
                Nazwisko = e.Ename,
                Praca = e.Job

            }).ToList();
            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }



        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            Console.WriteLine("Przykład 6 query:");
            var res = from emp in Emps
                      join dept in Depts on emp.Deptno equals dept.Deptno
                      select new { Ename = emp.Ename, Job = emp.Job, Dname = dept.Dname };
            foreach (var e in res)
            {
                Console.WriteLine(e);
            } 

            Console.WriteLine("Przykład 6 lambda:");


            var res2 = Emps.Join(Depts, e => e.Deptno, d => d.Deptno, (emp, dept) => new { Ename = emp.Ename, Job = emp.Job, Dname = dept.Dname }).ToList();

            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            Console.WriteLine("Przykład 7 query:");

            var res = from emp in Emps
                      group emp by emp.Job into j
                      select new { Praca = j.Key, LiczbaPracownikow = j.Count() };

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Przykład 7 lambda:");

            var res2 = Emps.GroupBy(e => e.Job).Select(j => new { Praca = j.Key, LiczbaPracownikow = j.Count() }).ToList();

            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }



        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            Console.WriteLine("Przykład 8 query:");

            var res = (from emp in Emps
                       where emp.Job == "Backend programmer"
                       select 1).Any();

            Console.WriteLine(res);

            Console.WriteLine("Przykład 8 lambda:");

            var res2 = Emps.Where(e => e.Job == "Backend programmer").Any();

            Console.WriteLine(res2);




        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            Console.WriteLine("Przykład 9 query:");
            var res = (from emp in Emps
                       where emp.Job == "Frontend programmer"
                       orderby emp.HireDate descending
                       select emp).Take(1).ToList();

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Przykład 9 lambda:");

            var res2 = Emps.Where(e => e.Job == "Frontend programmer").OrderByDescending(e => e.HireDate).Take(1);

            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }


        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            Console.WriteLine("Przykład 10 query:");
            var res = (from emp in Emps
                       select new { Ename = (string)emp.Ename, Job = (string)emp.Job, Hiredate = (DateTime?)emp.HireDate }
                       ).Union(new[] { new { Ename = (string)"Brak wartości", Job = (string)null, Hiredate = (DateTime?)null } });

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Przykład 10 lambda:");
            var res2 = Emps.Select(emp =>  new { Ename = (string)emp.Ename, Job = (string)emp.Job, Hiredate = (DateTime?)emp.HireDate }
                       ).Union(new[] { new { Ename = (string)"Brak wartości", Job = (string)null, Hiredate = (DateTime?)null } });

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            Console.WriteLine("Przykład 11:");
            var res = Emps.Aggregate((a, b) => a.Salary > b.Salary ? a : b);
            Console.WriteLine(res);

        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            Console.WriteLine("Przykład 12:");
            var res = Depts.SelectMany(dept => Emps);
            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

        }
    }
}
