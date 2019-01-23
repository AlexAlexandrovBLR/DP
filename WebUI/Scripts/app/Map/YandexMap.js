
ymaps.ready(init);

function init() {
    // Создание карты.    
    var geoMap = new ymaps.Map("map",
        {
            // Координаты центра карты.
            // Порядок по умолчанию: «широта, долгота».
            // Чтобы не определять координаты центра карты вручную,
            // воспользуйтесь инструментом Определение координат.
            center: [53.90148610, 27.54265186],
            // Уровень масштабирования. Допустимые значения:
            // от 0 (весь мир) до 19.
            zoom: 7
        });
    geoMap.controls.remove('searchControl');
    geoMap.behaviors.disable('scrollZoom');
    getRoutes(geoMap);
}

function getRoutes(geoMap) {
    $.ajax({
        url: 'route/getroutes',
        method: 'POST',
        success: function (data) {
            setRoutes(data, geoMap);
        }
    });
}

function setRoutes(data, geoMap) {

    data.forEach(function(item) {
        var departurePoin = item.CoordinatesDeparture;
        var arrivalPoint = item.CoordinatesArrival;

        var multiRoute = new ymaps.multiRouter.MultiRoute({
                // Точки маршрута. Точки могут быть заданы как координатами, так и адресом. 
                referencePoints: [
                    [departurePoin.Latitude, departurePoin.Longitude],
                    [arrivalPoint.Latitude, arrivalPoint.Longitude],
            ],
                params: {
                    // Ограничение на максимальное количество маршрутов, возвращаемое маршрутизатором.
                    results: 1
                }
            },

            {
                options: {
                    // Автоматически устанавливать границы карты так,
                    // чтобы маршрут был виден целиком.
                    boundsAutoApply: false
                }
            });

        multiRoute.model.events.once("requestsuccess", function () {
            var yandexWaStartyPoint = multiRoute.getWayPoints().get(0);
            var yandexWaFinishPoint = multiRoute.getWayPoints().get(1);
            setNameStop(item.DepartureBusStopName, yandexWaStartyPoint);
            setNameStop(item.ArrivalBusStopName, yandexWaFinishPoint);
        });
       

        geoMap.geoObjects.add(multiRoute);
    });

}

function setNameStop(name, point) {
    point.properties.set({ myPosition: name });
    point.options.set({
        iconContentLayout: ymaps.templateLayoutFactory.createClass('{{ properties.myPosition }}')
    });
}

function getNewPoints(name, coordinates) {

    var point = new ymaps.GeoObject({
            // Описание геометрии.
            geometry: {
                type: "Point",
                coordinates: [coordinates.Latitude, coordinates.Longitude]
            },
            // Свойства.
            properties: {
                // Контент метки.
                iconContent: name   
            }
        },
        {
            // Опции.
            // Иконка метки будет растягиваться под размер ее содержимого.
            preset: 'islands#blackStretchyIcon',
            // Метку можно перемещать.
            draggable: false
        });

    return point;
}
