﻿using RepositoryPattern.DAL;
namespace RepositoryPattern.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int studentId);
        void Add(Student student);
        void Update(Student student);
        void Delete(int studentId);
        void Save();
    }
}