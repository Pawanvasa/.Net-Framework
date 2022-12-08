//Communication between objects
//Helps us to extend the applications

using EventsExample;

Video video = new Video() { title="Video-1"};
VideoEncoder encoder = new VideoEncoder();
MailServices mailServices = new MailServices();
MessageServices messageServices = new MessageServices();

encoder.VideoEcoded += mailServices.OnVideoEncoded;
encoder.VideoEcoded+=messageServices.OnVideoEncoded;
encoder.Encode(video);