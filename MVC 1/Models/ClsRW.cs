using MVC_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ClsRW
{
    public void MergeFiles(string file1, string file2, string outputFile)
    {
        var lines1 = File.ReadAllLines(file1);
        var lines2 = File.ReadAllLines(file2);
        var allLines = lines1.Concat(lines2).ToList();

        var employees = allLines.Select(line =>
        {
            var parts = line.Split(',');
            return new Employee
            {
                EmployeeName = parts[0].Trim(),
                Department = int.Parse(parts[1].Trim()),
                PhoneNumber = parts[2].Trim()
            };
        }).ToList();

        employees = employees.OrderBy(e => e.Department).ToList();

        File.WriteAllLines(outputFile, employees.Select(e => $"{e.EmployeeName}, {e.Department}, {e.PhoneNumber}"));
    }

    public List<Employee> ReadMergedFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines.Select(line =>
        {
            var parts = line.Split(',');
            return new Employee
            {
                EmployeeName = parts[0].Trim(),
                Department = int.Parse(parts[1].Trim()),
                PhoneNumber = parts[2].Trim()
            };
        }).ToList();
    }
}

