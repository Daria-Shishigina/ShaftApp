using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaftApp;

namespace ShaftApp
{
    public class Parameters
    {
        /// <summary>
        /// Описание полей
        /// </summary>
        private double _diameterBracing;
        private double _diameterHead;
        private double _diameterLeg;
        private double _lengthBracing;
        private double _lengthHead;
        private double _lengthLeg;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="diameterBracing"></param>
        /// <param name="diameterHead"></param>
        /// <param name="diameterLeg"></param>
        /// <param name="lengthBracing"></param>
        /// <param name="lengthHead"></param>
        /// <param name="lengthLeg"></param>
        public Parameters(double diameterBracing,
            double diameterHead, 
            double diameterLeg,
            double lengthBracing, 
            double lengthHead, 
            double lengthLeg)
        {
            this._diameterBracing = diameterBracing;
            this._diameterHead = diameterHead;
            this._diameterLeg = diameterLeg;
            this._lengthBracing = lengthBracing;
            this._lengthHead = lengthHead;
            this._lengthLeg = lengthLeg;

              Validate();

        }



        private void Validate()
        {

            if (_diameterBracing<_diameterLeg || _diameterBracing < 20 || _diameterBracing > 2) 
            {
                throw new ArgumentException("Диаметр крепления должен быть меньше диаметра ножки, от 2 до 20 см"); 
            }



            if (_diameterLeg < _diameterHead || _diameterLeg < 30|| _diameterLeg > 3)  
            {
                throw new ArgumentException("Диаметр ножки должен быть меньше диаметра головки , от 3 до 30 см");
            }


            if (_diameterHead < 40|| _diameterHead > 4)  // добавить от скольки долен быть 
            {
                throw new ArgumentException("Диаметр головки должен быть от 4 до 40 см");
            }


            if (_lengthBracing < _lengthLeg || _lengthBracing < 25|| _lengthBracing>2)  // добавить от скольки долен быть 
            {
                throw new ArgumentException("Длина крепления должна быть меньше длины ножки, от 2 до 25 см");
            }


            if (_lengthLeg < 40|| _lengthLeg > 4)  // добавить от скольки долен быть 
            {
                throw new ArgumentException("Длина ножки должна быть от 4 до 40 см");
            }


            if ( _lengthHead < 20|| _lengthHead>2 || _lengthHead<_lengthLeg)  // добавить от скольки долен быть 
            {
                throw new ArgumentException("Длина крепления должна быть меньше длины ножки, от 2 до 20 см");
            }


        }





        /// <summary>
        /// Свойства (геттры параметров)
        /// </summary>
        public double DiameterBracing => _diameterBracing;
        //{
        //    get
        //    {
        //        return _diameterBracing;
        //    }
        //}
        public double DiameterHead => _diameterHead;
        public double DiameterLeg => _diameterLeg;
        public double LengthBracing => _lengthBracing;
        public double LengthHead => _lengthHead;
        public double LengthLeg => _lengthLeg;



    }


}
