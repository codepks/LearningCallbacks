//This is what we want
//Main Class
internal class MainClass
{

    static void Main()
    {
        Satellite Indraprastha = new Satellite();

        //this data will not be sent anywhere as there are no subscribers
        Indraprastha.SatelliteUpdate(new GPSStruct(10.3, 10.3));

        // Adding subscribers now
        // One mobile gps requests for subscription
        GPSObservers mobileGPS = new GPSObservers("Mobile GPS");
        mobileGPS.SusbcribeToSatellite(Indraprastha);

        Indraprastha.SatelliteUpdate(new GPSStruct(10.53, 10.73));
    }
}


//GPS structure
 struct GPSStruct
 {
     public double latitude { get; set; }
     public double longitude { get; set; }

     public GPSStruct(double latitude, double longitude)
     {
         this.latitude = latitude;   
         this.longitude = longitude;
     }

 }

// Satellite which sends data
 internal class Satellite : IObservable<GPSStruct>
 {
     // mandatory Implementing basic function
     private List<IObserver<GPSStruct>> subscribers_ = new List<IObserver<GPSStruct>>();
     public IDisposable Subscribe (IObserver<GPSStruct> subscriber)  {
         subscribers_.Add(subscriber);
         return new DisposableSubscriber( subscriber, subscribers_);
     }

     // required - Notifying GPS Location update
     public void SatelliteUpdate(GPSStruct gpsdata)  {
         //send update to all the subscribers wit latest data
         if (subscribers_.Count > 0)
         {
             foreach (var subscriber in subscribers_)
             {
                 subscriber.OnNext(gpsdata);
             }
         }
     }

     // required - to finalize the clearing of the observers
     public void SatellingUpdateEnds()   {
         foreach (var subscriber in subscribers_)    {
             subscriber.OnCompleted();
         }
         subscribers_.Clear();
     }


     /* This class's object is returned on observer subscription in Subscribe method
      * so that un-subscribe can happen with DiposableObserver.Dispose() call which removes observer from the list
     */
     private class DisposableSubscriber : IDisposable
     {
         //maintains observers and current observer list
         private IObserver<GPSStruct>? subscriber_;
         private List<IObserver<GPSStruct>>? subscribers_;

         public DisposableSubscriber(IObserver<GPSStruct> subscriber, List<IObserver<GPSStruct>> subscribers)
         {
             subscriber_ = subscriber;
             subscribers_ = subscribers;
         }

         //need to implement Dispose() function
         public void Dispose ()
         {
             if(subscriber_ != null)
                 subscribers_?.Remove(subscriber_);
         }


     }
 }

// Mobile GPS to gather data
 internal class GPSObservers : IObserver<GPSStruct>
 {
     private string _name;
     private IObservable<GPSStruct> _satellite;
     private IDisposable _observerDisposeMe;
     public GPSObservers(string name) {
         _name = name;
     }

     // mandatory 
     public void OnCompleted() {
         Console.WriteLine("The GPS transmission is done");
     }

     // mandatory 
     public void OnError(Exception error) {
         Console.WriteLine($"Error: {error}");
     }

     // mandatory 
     public void OnNext(GPSStruct value) {
         Console.WriteLine($"Displaying longitude value {value.longitude}");
         Console.WriteLine($"Displaying longitude value {value.latitude}");
     }

     // required
     public void SusbcribeToSatellite(Satellite satellite)
     {
         _satellite = satellite;
         _observerDisposeMe = satellite.Subscribe(this);
     }


     public void RemoveMySubscription()
     {
         _observerDisposeMe.Dispose();
     }

 }
