using System;

namespace 外观者模式
{
    class Program
    {
        private static RegistrationFacade _registrationFacade = new RegistrationFacade();
        static void Main(string[] args)
        {
            if (_registrationFacade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();
        }
    }

    public class RegistrationFacade
    {
        private NotifyStudent _notifyStudent;
        private RegisterCourse _registerCourse;

        public RegistrationFacade()
        {
            _notifyStudent = new NotifyStudent();
            _registerCourse = new RegisterCourse();
        }

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!_registerCourse.CheckAvailable(courseName))
            {
                return false;
            }
            return _notifyStudent.Notify(studentName);
        }
    }


    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine($"正在验证课程{courseName}是否人数已满");
            return true;
        }
    }

    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine($"正在向{studentName}发生通知");
            return true;
        }
    }
}
