﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectSalon
{
    public class Controller
    {
        DataStorage mainDataStorage;

        public Controller()
        {
            this.mainDataStorage = DataStorage.get();
        }
        /// <summary>
        /// Проводит создание и начальную подготовку объекта класса Master
        /// </summary>
        /// <param name="targetMaster">экземпляр объекта, сгенерированный в интерфейсе</param>
        public void registerMaster(string name, int salary, List<String> serviceNames)
        {
            Debug.WriteLine("Запущен registerMaster");
            List<Service> finalServiceList = new List<Service>();
            Debug.WriteLine("Количество названий услуг, полученных контроллером " + serviceNames.Count);
            foreach (String serviceName in serviceNames)
            {
                Service targetService = getService(serviceName);
                if (targetService == null)
                {
                    Debug.WriteLine("Запись не найдена при создании мастера");
                }
                else
                    finalServiceList.Add(targetService);
                targetService = null;
            }
            Master master = mainDataStorage.newMaster(name, salary);
            mainDataStorage.getSalon().addMaster(master);

            foreach (Service finalService in finalServiceList)
            {
                master.addService(finalService);
                finalService.addMaster(master);
                Debug.WriteLine("Добавили услугу " + finalService.name + " мастеру " + master.name);
            }
        }

        /// <summary>
        /// Проводит создание и начальную подготовку объекта класса Record
        /// </summary>
        /// <param name="targetRecord">экземпляр объекта, сгенерированный в интерфейсе</param>
        public void registerRecord(Service service, Master master, Client client, DateTime day, int hour)
        {
            mainDataStorage.getSalon().addRecord(service, master, client, day, hour);
        }

        public void registerClient(String name, String birth, String number)
        {
            Client client = mainDataStorage.newClient(name, birth, number);
            //TODO: Здесь явно что-то еще...
        }

        public void registerService(String name, int price, int duration)
        {
            Service newService = mainDataStorage.newService(name, price, duration);
        }



        /// <summary>
        /// Проводит создание и начальную подготовку объекта класса Salon
        /// </summary>
        /// <param name="targetRecord">экземпляр объекта, сгенерированный в интерфейсе</param>
        public void registerSalon(String adress, String name)
        {
            Salon newSalon = mainDataStorage.newSalon(adress, name);
        }



        /// <summary>
        /// Выводит список клиентов салона 
        /// </summary>
        /// <param name="request">запрос для поиска, если request==null, возвращает полный список</param>
        /// <returns>Список клиентов, содержащих в своих полях подстроку request</returns>
        public List<Client> getClientList(string request)
        {
            Salon salon = mainDataStorage.getSalon();

            return salon.getClientList(request);
        }

        /// <summary>
        /// Выводит список мастеров салона 
        /// </summary>
        /// <param name="request">запрос для поиска, если request==null, возвращает полный список</param>
        /// <returns>Список мастеров, содержащих в своих полях подстроку request</returns>
        public List<Master> getMasterList(string request)
        {
            Salon salon = mainDataStorage.getSalon();

            return salon.getMasterList(request);
        }

        /// <summary>
        /// Выводит список записей салона 
        /// </summary>
        /// <param name="request">запрос для поиска, если request==null, возвращает полный список</param>
        /// <returns>Список записей, содержащих в своих полях подстроку request</returns>
        public List<Record> getRecordList(string request)
        {
            Salon salon = mainDataStorage.getSalon();

            return salon.getRecordList(request);
        }

        /// <summary>
        /// Выводит список услуг салона 
        /// </summary>
        /// <param name="request">запрос для поиска, если request==null, возвращает полный список</param>
        /// <returns>Список услуг, содержащих в своих полях подстроку request</returns>
        public List<Service> getServiceList(string request)
        {
            Salon salon = mainDataStorage.getSalon();
            
            return salon.getServiceList(request);
        }

        public Service getService(string name)
        {
            List<Service> tmpServiceList = getServiceList(name);
            foreach (Service tmpService in tmpServiceList)
            {
                if (tmpService.name == name)
                {
                    return tmpService;
                }
            }
            return null;
        }

        public Client getClient(String number)
        {
            List<Client> clientList = getClientList("");
            foreach (Client client in clientList)
            {
                if (client.number == number)
                    return client;
            }
            return null;
        }
    }
}
