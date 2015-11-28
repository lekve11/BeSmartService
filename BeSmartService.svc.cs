﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BeSmartService.DAL;
using BeSmartService.DTO;
using BeSmartService.ExceptionHandlers;
using BeSmartService.GOF;
using log4net;
using log4net.Config;

namespace BeSmartService
{

    public class BeSmartService : IBeSmartService
    {
        public BeSmartService()
        {
            XmlConfigurator.Configure();
            AutoMapperConfigurator.Configure();
        }

        #region GET



        public ResponseData<List<TestCreatorUser>> GetTestCreators()
        {
            ResponseData<List<TestCreatorUser>> response = new ResponseData<List<TestCreatorUser>>();

            
            var facade = new TestCreatorFacade();
            
            try
            {
                response.Data = facade.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);
            }
           

            return response;
        }

        public ResponseData<TestCreatorUser> GetTestCreatorUserById(string userName)
        {
            ResponseData<TestCreatorUser> response = new ResponseData<TestCreatorUser>();

            var facade = new TestCreatorFacade();

            try
            {
                response.Data = facade.GetById(userName);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);
            }

            return response;
        }

        public ResponseData<List<Interest>> GetInterests()
        {
            ResponseData<List<Interest>> response = new ResponseData<List<Interest>>();


            var facade = new InterestFacade();

            try
            {
                response.Data = facade.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);
            }


            return response;
        }

        public ResponseData<Interest> GetInterestById(string Id)
        {
            ResponseData<Interest> response = new ResponseData<Interest>();

            int currId = 0;

            int.TryParse(Id, out currId);

            var facade = new InterestFacade();

            try
            {
                if(currId!=0)
                response.Data = facade.GetById(currId);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);
            }

            return response;
        }

        public ResponseData<List<Subject>> GetSubjects()
        {
            ResponseData<List<Subject>> response = new ResponseData<List<Subject>>();

            SubjectFacade facade = new SubjectFacade();

            try
            {
                response.Data = facade.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);
            }

            return response;
        }

        public ResponseData<Subject> GetSubjectById(string id)
        {
            ResponseData<Subject> response = new ResponseData<Subject>();

            int currId = 0;

            int.TryParse(id, out currId);

            if (currId != default(int))
            {
                try
                {
                    SubjectFacade subjectFacade = new SubjectFacade();
                    response.Data = subjectFacade.GetById(currId);
                }
                catch (Exception ex)
                {
                    ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);

                }
            }

            return response;
        }

        #endregion

        #region SAVE

        public ResponseData<int> SaveTestCreatorUser(SaveTestCreatorUser savableData)
        {
            ResponseData<int> resp = new ResponseData<int>();

            savableData.Password = this.getSha256(savableData.UserName, savableData.Password);

            TestCreatorFacade facade = new TestCreatorFacade();
            try
            {
                facade.Save(savableData);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(resp).Handle(ex);
            }

            return resp;
        }

        public ResponseData<int> SaveInterest(SaveInterest savableData)
        {
            ResponseData<int> resp = new ResponseData<int>();
            
            try
            {
                InterestFacade facade = new InterestFacade();
                facade.Save(savableData);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(resp).Handle(ex);
            }

            return resp;
        }

        public ResponseData<int> SaveSubject(SaveSubject saveSubject)
        {
            ResponseData<int> response = new ResponseData<int>();

            SubjectFacade facade = new SubjectFacade();
            try
            {
                response.Data = facade.Save(saveSubject);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);

            }

            return response;
        }
        #endregion

        #region DELETE
        public ResponseData<object> DeleteTestCreatorUser(DeleteTestCreatorUser deleteTestCreatorUser)
        {
            ResponseData<object> resp = new ResponseData<object>();

            var facade = new TestCreatorFacade();

            try
            {
                facade.Delete(deleteTestCreatorUser);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(resp).Handle(ex);
            }

            return resp;
        }

        public ResponseData<object> DeleteInterest(DeleteInterest deleteInterest)
        {
            ResponseData<object> resp = new ResponseData<object>();

            var facade = new InterestFacade();

            try
            {
                facade.Delete(deleteInterest);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(resp).Handle(ex);
            }

            return resp;
        }

        public ResponseData<object> DeleteSubject(DeleteSubject deleteSubject)
        {
            ResponseData<object> response = new ResponseData<object>();

            SubjectFacade facade = new SubjectFacade();

            try
            {
                facade.Delete(deleteSubject);
            }
            catch (Exception ex)
            {
                ExceptionHandlerFactory.Factory.GetResponseExceptionHandler(response).Handle(ex);
            }

            return response;
        }
        #endregion

        private string getSha256(string userName,string password)
        {
            char[] charArr = userName.ToCharArray();

            Array.Reverse(charArr);

            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            password += new string(charArr);
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

       
    }
}