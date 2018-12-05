

#include "opencv2/text.hpp"
#include "opencv2/core/utility.hpp"
#include "opencv2/highgui.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/ml.hpp"


#include <iostream>

#pragma comment( lib, "opencv_imgproc400d.lib" )
#pragma comment( lib, "opencv_highgui400d.lib" )
#pragma comment( lib, "opencv_core400d.lib" )
#pragma comment( lib, "opencv_text400d.lib" )
#pragma comment( lib, "opencv_imgcodecs400d.lib" )
#pragma comment( lib, "opencv_ml400d.lib" )

using namespace std;
using namespace cv;
using namespace cv::text;
using namespace cv::ml;

void main()
{
	// create traning data

	Mat classes;
	Mat trainingData;
	vector<int> trainingLabels;

	double start_tick = ( double )getTickCount();

	int taning_image_cnt = 4;
	for( int i = 0; i < taning_image_cnt; i++ ) {
		stringstream ss( stringstream::in | stringstream::out );
		ss << "C:/training_image/" << i << ".png";
		string str = ss.str();

		Mat img = imread( str, 0 );
		img.convertTo( img, CV_32F );

		trainingData.push_back( img );
		trainingLabels.push_back( i );

		trainingData.convertTo( trainingData, CV_32FC1 );
		Mat( trainingLabels ).copyTo( classes );
	}

	cout << "TRAINING_TIME = " << ( ( double )getTickCount() - start_tick ) * 1000 / getTickFrequency() << " msec" << endl;

	FileStorage fs( "C:/OCR_TrainedData.xml", FileStorage::WRITE );
	fs << "TrainingData" << trainingData;
	fs << "Classes" << classes;
	fs.release();
	





	// machine learning
	Mat TrainData_Mat = trainingData;
	int layer_count = 1;
	int number_characters = taning_image_cnt;

	Mat layres( 1, 3, CV_32SC1 );
	layres.at< int >( 0 ) = TrainData_Mat.cols;
	layres.at< int >( 1 ) = layer_count;
	layres.at< int >( 2 ) = number_characters;
	Ptr< ANN_MLP > ann = ANN_MLP::create();
	ann->setLayerSizes( layer_count );
	ann->setActivationFunction( ANN_MLP::SIGMOID_SYM, 1, 1 );


	// tranClasses �غ�
	// m�� ���ܸ�ŭ n���� �Ʒõ� �����Ͱ� �ִ� ����� �����Ѵ�.
	Mat trainClasses;
	trainClasses.create( TrainData_Mat.rows, number_characters, CV_32FC1 );

	for( int i = 0; i < trainClasses.rows; i++ ) {
		for( int k = 0; k < trainClasses.cols; k++ ) {
			// ������ ������ i�� k���ܰ� ������
			trainClasses.at< float >( i, k ) = ( k == classes.at< int >( i ) ) ? 1 : 0;
		}
	}

	Mat weights( 1, TrainData_Mat.rows, CV_32FC1, Scalar::all( 1 ) );

	Ptr< TrainData > td = TrainData::create( trainingData, 3, trainClasses );

	// �з��� �н�
	ann->train( td );



	Mat img1 = imread( "C:/training_image/1.png", 0 );
	img1.convertTo( img1, CV_32F );

	Mat trainingData1;
	trainingData1.push_back( img1 );
	trainingData1.convertTo( trainingData1, CV_32FC1 );

	Mat output( 1, number_characters, CV_32FC1 );
	ann->predict( trainingData1, output );

	Point maxLoc;
	double maxVal;
	minMaxLoc( output, 0, &maxVal, 0, &maxLoc );
}