function initMap() {
    var pos = { lat: 10.0099974, lng: 76.3656594 };
    var map = new google.maps.Map(document.getElementById('googleMap'), {
        zoom: 15,
        center: pos
    });
    var marker = new google.maps.Marker({
        position: pos,
        map: map
    });
}