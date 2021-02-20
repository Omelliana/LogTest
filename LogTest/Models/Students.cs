using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace LogTest.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public class Students
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        
        private readonly List<Student> _studentList = new List<Student>()
        {
            new Student() {Id = 1, Name = "George", Age = 19},
            new Student() {Id = 2, Name = "john", Age = 22},
            new Student() {Id = 3, Name = "Mark", Age = 27}
        };

        public List<Student> GetStudents()
        {
            _logger.Debug("Произведено подключение к базе данных.");
            return _studentList;
        }

        
        public Student GetStudentById(int id)
        {
            _logger.Trace("Запрашиваемый id студента: " + id);
            _logger.Trace("Попытка подключения к источнику данных");
            var student = _studentList.FirstOrDefault(x => x.Id == id);
            if (student == null)
                _logger.Error("Студента с id = " + id + " нет.");
            if (student.Age < 15)
                _logger.Warn("Неправильный возраст студента");
            _logger.Trace("Успешная выборка. Студент с id = " + student.Id);
            return student;
        }
    }
}