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
        public Parameters(double diameterBracing, double diameterHead, double diameterLeg, double lengthBracing, double lengthHead, double lengthLeg)
        {
            this._diameterBracing = diameterBracing;
            this._diameterHead = diameterHead;
            this._diameterLeg = diameterLeg;
            this._lengthBracing = lengthBracing;
            this._lengthHead = lengthHead;
            this._lengthLeg = lengthLeg;

            //  Validate();

        }



        private void Validate()
        {


           //////////////////////////////////////////////


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
