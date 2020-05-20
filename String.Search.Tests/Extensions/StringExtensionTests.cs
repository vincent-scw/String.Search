﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using String.Search.Extensions;

namespace String.Search.Tests.Extensions
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void StringSearch_Should_ReturnExpected()
        {
            var text = @"It’s a technique for building a computer program that learns from data. 
It is based very loosely on how we think the human brain works. 
First, a collection of software “neurons” are created and connected together, 
allowing them to send messages to each other. Next, the network is asked to solve a problem, 
which it attempts to do over and over, each time strengthening the connections that lead to success and diminishing those that lead to failure. 
For a more detailed introduction to neural networks, Michael Nielsen’s Neural Networks and Deep Learning is a good place to start. For a more technical overview, 
try Deep Learning by Ian Goodfellow, Yoshua Bengio, and Aaron Courville.";

            var tf = new AcFinder(new List<string>
            {
                "Deep Learning",
                "brain",
                "neural networks"
            });

            var results = text.Search(tf).ToArray();

            Assert.AreEqual(5, results.Length);
            Assert.AreEqual(1, results.Where(x => x.value == "neural networks").Count());
            Assert.AreEqual(1, results.Where(x => x.value == "Neural Networks").Count());
            Assert.AreEqual(2, results.Where(x => x.value == "Deep Learning").Count());
        }

        [TestMethod]
        public void StringSearch_Unicode_Should_ReturnExpected()
        {
            var text = @"机器学习是人工智能的一个分支。
人工智能的研究历史有着一条从以“推理”为重点，到以“知识”为重点，再到以“学习”为重点的自然、清晰的脉络。显然，机器学习是实现人工智能的一个途径，即以机器学习为手段解决人工智能中的问题。
机器学习在近30多年已发展为一门多领域交叉学科，涉及概率论、统计学、逼近论、凸分析、计算复杂性理论等多门学科。机器学习理论主要是设计和分析一些让计算机可以自动“学习”的算法。";

            var tf = new AcFinder(new List<string>
            {
                "机器学习",
                "人工智能"
            });

            var results = text.Search(tf).ToArray();

            Assert.AreEqual(9, results.Length);
            Assert.AreEqual(5, results.Where(x => x.value == "机器学习").Count());
            Assert.AreEqual(4, results.Where(x => x.value == "人工智能").Count());
        }
    }
}
