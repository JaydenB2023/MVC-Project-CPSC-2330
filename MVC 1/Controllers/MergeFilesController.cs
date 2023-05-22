using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;
using System.Collections.Generic;

public class MergeFilesController : Controller
{
    private readonly ClsRW _clsRW;

    public MergeFilesController()
    {
        _clsRW = new ClsRW();
    }

    public IActionResult Index()
    {
        var file1 = "C:\\AU Classes\\CPSC 2330 Web App Development\\Big Projects\\MVC 1\\File1.txt";
        var file2 = "C:\\AU Classes\\CPSC 2330 Web App Development\\Big Projects\\MVC 1\\File2.txt";
        var mergedFile = "C:\\AU Classes\\CPSC 2330 Web App Development\\Big Projects\\MVC 1\\File3.txt";
        _clsRW.MergeFiles(file1, file2, mergedFile);

        List<Employee> employees = _clsRW.ReadMergedFile(mergedFile);

        return View(employees);
    }
}

