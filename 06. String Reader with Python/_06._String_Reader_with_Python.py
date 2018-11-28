import cv2
import numpy as np

src_path = "C:\\"

def get_string( img_path ) :
	img = cv2.imread( img_path )
	img = cv2.cvtColor( img, cv2.COLOR_RGB2GRAY )
	kernel = np.ones( ( 1, 1 ), np.uint8 )
	img = cv2.dilate( img, kernel, iteration = 1 )
	img = cv2.erode( img, kernel, iteration = 1 )
	
	cv2.imwrite( src_path + "removed_noise.png", img )
	img = cv2.adaptiveThreshold( img, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 11, 2 )
	cv2.imwrite( src_path + "thres.png", img )
	result = pytesseract.image_to_string( Image.open( src_path + "thres.png" ) )
	return result

print( get_string( src_path + "1.png" ) )