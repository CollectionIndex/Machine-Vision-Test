
#include <opencv2\opencv.hpp>
#include <opencv2\text.hpp>
#include <iostream>

#pragma comment( lib, "opencv_text400d.lib" )
#pragma comment( lib, "opencv_core400d.lib" )
#pragma comment( lib, "opencv_imgcodecs400d.lib" )

using namespace std;
using namespace cv;
using namespace cv::text;

void main()
{
	Mat image = imread( "C:\\string_reader_read.png" );

	string voca = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	//Ptr< OCRHMMDecoder::ClassifierCallback > ocr = loadOCRHMMClassifierCNN( "D:\\opencv\\testdata\\contrib\\text\\OCRBeamSearch_CNN_model_data.xml.gz" );
	//vector< int > out_classes;
	//vector< double > out_confidences;
	//ocr->eval( image, out_classes, out_confidences );
	//for( int i = 0; i < voca.size(); i++ ) {
	//	cout << "OCR output = \"" << voca[ out_classes[ i ] ] << "\" with confidence "
	//		<< out_confidences[ i ] << endl;
	//}



	Ptr< OCRBeamSearchDecoder::ClassifierCallback > ocr = loadOCRBeamSearchClassifierCNN( "D:\\opencv\\testdata\\contrib\\text\\OCRBeamSearch_CNN_model_data.xml.gz" );
	std::vector< std::vector<double> > recognition_probabilities;
	std::vector<int> oversegmentation;
	ocr->eval( image, recognition_probabilities, oversegmentation );
}