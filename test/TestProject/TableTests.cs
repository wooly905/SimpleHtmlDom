using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleHtmlDom.Elements;
using Xunit;

namespace TestProject
{
    public class TableTests
    {
        [Fact]
        public void SimpleTest()
        {
            List<TestData> data = new List<TestData>();
            TestData element1 = new TestData { Id = 1, Name = "Name 1" };
            data.Add(element1);
            string id = "id1";
            string name = "name1";
            string style = "color:red";
            Table<TestData> table = new Table<TestData>(data, id: id, name: name, style: style);
            string actual = table.ToHtml();

            Assert.Equal($"<table width=\"100%\" id=\"{id}\" name=\"{name}\" style=\"{style}\"><tr><th>Name</th><th>Id</th></tr><tr><td>Name 1</td><td>1</td></tr></table>", actual);
        }

        [Fact]
        public void DataNameTest()
        {
            DateTime now = DateTime.Now;
            List<TestData2> data = new List<TestData2>();
            TestData2 element1 = new TestData2 { Id = 1, Name = "Name 1", CreatedTime = now };
            data.Add(element1);
            Table<TestData2> table = new Table<TestData2>(data);
            string actual = table.ToHtml();

            Assert.Equal($"<table width=\"100%\"><tr><th>First Name</th><th>Member Id</th><th>Created Time</th></tr><tr><td>Name 1</td><td>1</td><td>{now}</td></tr></table>", actual);
        }

        [Fact]
        public void MultiElementsTest()
        {
            List<TestData> data = new List<TestData>();
            TestData element1 = new TestData { Id = 1, Name = "Name 1" };
            data.Add(element1);
            Table<TestData> table = new Table<TestData>(data);
            Division div = new Division(table);
            string actual = div.ToHtml();

            Assert.Equal("<div><table width=\"100%\"><tr><th>Name</th><th>Id</th></tr><tr><td>Name 1</td><td>1</td></tr></table></div>", actual);
        }

        [Fact]
        public void TableFuncTest()
        {
            List<TestData3> data = new List<TestData3>();
            TestData3 d3 = new TestData3(new List<string>() { "a", "b" });
            TestData3 d4 = new TestData3(new List<string>() { "c", "d" });
            data.Add(d3);
            data.Add(d4);

            Dictionary<string, Func<TestData3, string>> convertors = new Dictionary<string, Func<TestData3, string>>();
            convertors.Add(nameof(TestData3.Data), (x) => x.GetData());
            Table<TestData3> table = new Table<TestData3>(data, convertors);
            string actual = table.ToHtml();

            Assert.Equal("<table width=\"100%\"><tr><th>Test Data</th></tr><tr><td>a;b</td></tr><tr><td>c;d</td></tr></table>", actual);
        }
    }

    class TestData
    {
        public string Name { get; set; }
        public int Id { get; set; }

        // private member will not be displayed
        private string Data { get; set; }
    }

    class TestData2
    {
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Display(Name = "Member Id")]
        public int Id { get; set; }

        [Display(Name = "Created Time")]
        public DateTime CreatedTime { get; set; }

        // private member will not be displayed
        [Display(Name = "Private Data")]
        private string Data { get; set; }
    }

    class TestData3
    {
        public TestData3(IReadOnlyList<string> data)
        {
            Data = data;
        }

        [Display(Name = "Test Data")]
        public IReadOnlyList<string> Data { get; }

        public string GetData()
        {
            return string.Join(";", Data);
        }
    }
}
