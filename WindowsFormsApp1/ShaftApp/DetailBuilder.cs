using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using ShaftApp;

namespace ShaftApp
{
    public class DetailBuilder
    {
        /// <summary>
        /// экземпляр компаса 
        /// </summary>
        private KompasConnector _kompasconnector;
        private KompasObject _kompas;


        private Document3D _doc3D;
        private ksEntity _entity;
        private ksPart _part;


        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="kompasConnector"></param>
        public DetailBuilder(KompasObject kompas)
        {
            this._kompas = kompas;
        }


        public void BuildDetail(Parameters parameters)
        {
         
            _doc3D = _kompas.Document3D();
            _doc3D.Create(false, true);///

            BuildModel(parameters.DiameterBracing, parameters.DiameterHead, parameters.DiameterLeg);
            BuildExtrusion(parameters.LengthBracing, parameters.LengthHead, parameters.LengthLeg);

        }


        /// <summary>
        /// Создание эскиза 
        /// </summary>
        /// <param name="diameterBracing"></param>
        /// <param name="diameterHead"></param>
        /// <param name="diameterLeg"></param>
        private void BuildModel(double diameterBracing,double diameterHead,double diameterLeg)
        {

            #region Константы для эскиза
            // Тип компо­нента Get Param. Главный компонент, в составе которо­го находится новый или редактируе­мый компонент.
            const int pTop_part = -1;

            //Тип объекта NewEntity. Указывает на создание эскиза.
            const int o3d_sketch = 5;

            // Тип объекта GetDefaultEntity. Указывает на работу в плостости XOY.
            const int o3d_planeXOY = 1;
            #endregion


            _part = _doc3D.GetPart(pTop_part);
            //Получаем интерфейс объекта "Эскиз"
            _entity = _part.NewEntity(o3d_sketch);
            //Получаем интерфейс параметров эскиза
            ksSketchDefinition SketchDefinition = _entity.GetDefinition();
            //Получаем интерфейс объекта "плоскость XOY"
            ksEntity EntityPlane = _part.GetDefaultEntity(o3d_planeXOY);
            //Устанавливаем плоскость XOY базовой для эскиза
            SketchDefinition.SetPlane(EntityPlane);
            //Создаем эскиз
            _entity.Create();
            //Входим в режим редактирования эскиза
            ksDocument2D Document2D = SketchDefinition.BeginEdit();
            //Строим окружность 
            Document2D.ksCircle(0, 0, diameterBracing / 2, 1);
    //        Document2D.ksCircle(0, 0, diameterHead / 2, 1);
   //         Document2D.ksCircle(0, 0, diameterLeg / 2, 1);
            //Выходим из режима редактирования эскиза
            SketchDefinition.EndEdit();
        }


        /// <summary>
        /// выдавливание
        /// </summary>
        /// <param name="lengthBracing"></param>
        /// <param name="lengthHead"></param>
        /// <param name="lengthLeg"></param>

        private void BuildExtrusion(double lengthBracing, double lengthHead, double lengthLeg)
        {
            #region Константы для выдавливания

            //Тип объекта NewEntity. Указывает на создание операции выдавливания.
            const int o3d_baseExtrusion = 24;
            // Тип обекта DrawMode. Устанавливает полутоновое изображение модели
            const int vm_Shaded = 3;
            //Тип выдавливания. Строго на глубину
            const int etBlind = 0;
            #endregion

            //Получаем интерфейс объекта "операция выдавливание"
            ksEntity EntityExtrusion = _part.NewEntity(o3d_baseExtrusion);
            //Получаем интерфейс параметров операции "выдавливание"
            ksBaseExtrusionDefinition BaseExtrusionDefinition = EntityExtrusion.GetDefinition();
            //Устанавливаем параметры операции выдавливания

            BaseExtrusionDefinition.SetSideParam(true, etBlind, lengthBracing, 0, true);
            BaseExtrusionDefinition.SetSideParam(false, etBlind, lengthLeg, 0, true);

            // BaseExtrusionDefinition.SetSideParam(true, etBlind, lengthLeg, 0, true);

            //BaseExtrusionDefinition.SetSideParam(true, etBlind, lengthHead, 0, true);





            //Устанавливаем эскиз операции выдавливания
            BaseExtrusionDefinition.SetSketch(_entity);
            //Создаем операцию выдавливания
            EntityExtrusion.Create();


            //Устанавливаем полутоновое изображение модели
            _doc3D.drawMode = vm_Shaded;
            //Включаем отображение каркаса
            _doc3D.shadedWireframe = true;
        }


    }
}
