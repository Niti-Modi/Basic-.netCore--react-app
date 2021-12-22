using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppReact_Core.Controllers;
using WebAppReact_Core.Models;

namespace WebAppReact_Core.Test.Controllers
{
    class DCandidateTester
    {
        private readonly DonationDBContext context;
        DCandidateController controller;
        public DCandidateTester() {

            var options = new DbContextOptionsBuilder<DonationDBContext>().UseInMemoryDatabase(databaseName: "DB1").Options;
            context = new DonationDBContext(options);
            Seed(context);
            controller = new DCandidateController(context);

        }
              

        [Test]
        public async Task ExecuteShouldReturnCorrectType() {

                       
            var ListOfCandidates =  await controller.GetDCandidates();
                       
            foreach (var elem in ListOfCandidates.Value) {
                System.Diagnostics.Debug.WriteLine(elem.address);
            }


            Assert.That(ListOfCandidates, Is.Not.Null);
            Assert.NotNull(ListOfCandidates);
            System.Diagnostics.Debug.WriteLine(ListOfCandidates.Value.Count());
            Assert.True(ListOfCandidates.Value.Count() == 3);
            Assert.AreEqual(ListOfCandidates.Value.Count(),3);
        }

        [Test]
        public async Task ShouldReturnNumberOfObjects()
        {

       
            var ListOfCandidates = await controller.GetDCandidates();

            System.Diagnostics.Debug.WriteLine(ListOfCandidates.Value.Count());
            Assert.True(ListOfCandidates.Value.Count() == 3);

        }

        




        private void Seed(DonationDBContext context) {

            var Candidates = new[]
            {
                new DCandidate { id=1, address="abc", age=10, bloodGroup="o+", email="abc@gmail.com", fullname="niti modi" , mobile="94283232"},
                new DCandidate { id=2, address="abac", age=10, bloodGroup="o+", email="abc@gmail.com", fullname="niti modi" , mobile="94283232"},
                new DCandidate { id=3, address="abac", age=10, bloodGroup="o+", email="abc@gmail.com", fullname="niti modi" , mobile="94283232"},


            };

            context.DCandidates.AddRange(Candidates);
            context.SaveChanges();


        }

        
    }
}
