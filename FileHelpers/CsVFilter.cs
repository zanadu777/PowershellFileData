using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelpers;

public class CsVFilter
{
    public CsVFilter(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string FilterFieldByValues(string field, string values)
    {
        field = field.ToUpper();

        var source = new FileInfo(SourcePath);
        if (!source.Exists)
            return ($"File {SourcePath} does not exist");

        var line = "";
        var splitline = new string[] { };

        using TextReader reader = File.OpenText(SourcePath);
        using TextWriter writer = File.CreateText(DestinationPath);
        line = reader.ReadLine();

        var fields = GetFields(line, ',');

        writer.WriteLine(line);


        while ((line = reader.ReadLine()) != null)
        {
            splitline = line.Split(',');
            if (splitline[fields[field]] == values)
                writer.WriteLine(line);
        }

        return "";
    }


    public string FilterFieldByValues(string field, string[] values)
    {
        field = field.ToUpper();

        var source = new FileInfo(SourcePath);
        if (!source.Exists)
            return ($"File {SourcePath} does not exist");

        var line = "";
        var splitline = new string[] { };

        using TextReader reader = File.OpenText(SourcePath);
        using TextWriter writer = File.CreateText(DestinationPath);
        line = reader.ReadLine();

        var fields = GetFields(line, ',');

        writer.WriteLine(line);


        while ((line = reader.ReadLine()) != null)
        {
            splitline = line.Split(',');
            var fieldValue = splitline[fields[field]];
            if (values.Contains(fieldValue))
                writer.WriteLine(line);
        }

        return "";
    }

    private Dictionary<string, int> GetFields(string header, char delimiter)
    {
        var fields = new Dictionary<string, int>();
        var parts = header.Split(delimiter);
        for (int i = 0; i < parts.Length; i++)
            fields[parts[i].Trim().ToUpper()] = i;

        return fields;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }
}