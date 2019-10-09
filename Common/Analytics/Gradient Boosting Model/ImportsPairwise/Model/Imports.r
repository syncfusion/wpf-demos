# Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
# Use of this code is subject to the terms of our license.
# A copy of the current license can be obtained at any time by e-mailing
# licensing@syncfusion.com. Any infringement will be prosecuted under
# applicable laws. 


# If you are not familiar with R you can obtain a quick introduction by downloading
# R Succinctly for free from Syncfusion - http://www.syncfusion.com/resources/techportal/ebooks/rsuccinctly
# R Succinctly is also included with this installation and is available here
# Installed Drive :\Program Files (x86)\Syncfusion\Essential Studio\XX.X.X.XX\Infrastructure\EBooks\R_Succintly.pdf OF R Succinctly
# Uncomment below lines to install necessary packages if not installed already
#install.packages("gbm")
#install.packages("devtools")
#install.packages("rJava
#install.packages("randomForest")
#install.packages("githubinstall")
#Use 'r2pmml' package version v0.3.0 or below since, the function 'pairwise' has been deprecated in later versions. 
#library(githubinstall)
#gh_install_packages("jpmml/r2pmml", ref="0.3.0")

# Load below packages
library(devtools)
library(gbm)
library(rJava)
library(r2pmml)
library(randomForest) # This package is specifically loaded for imports85 dataset shipped within it.


# Here we directly load the audit dataset installed with the "randomForest" package.
data(imports85)

# rename column names in imports85 dataset from randomForest package
importsOriginal <- setNames(imports85, c("Symboling","Normalized_Losses","Make","Fuel_Type","Aspiration","Num_Of_Doors","Body_Style","Drive_Wheels","Engine_Location",
"Wheel_Base","Length","Width","Height","Curb_Weight","Engine_Type","Num_Of_Cylinders","Engine_Size","Fuel_System","Bore","Stroke","Compression_Ratio",
"Horse_Power","Peak_Rpm","City_Mpg","Highway_Mpg","Price"))

# Omit rows with missing values
importsOriginal = na.omit(importsOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# imports= read.csv("Imports.csv")

# Divide dataset for training and test
trainData<-importsOriginal[1:128,]
testData<-importsOriginal[129:159,]

# Applying GBM - to predict poisson function 
imports_GBM =  gbm(Price~ Symboling+Normalized_Losses+Fuel_Type+Aspiration+
        Num_Of_Doors+Body_Style+Drive_Wheels+Wheel_Base+Length+Width+Height+
        Curb_Weight+Engine_Size+Bore+Stroke+Compression_Ratio+Horse_Power+
        Peak_Rpm+City_Mpg+Highway_Mpg,data=trainData,distribution=list(name="pairwise", group="Body_Style"))

# Display the predicted results 
# Predict "price" column probability for test data set
importsTestProbabilities = predict.gbm(imports_GBM, newdata=testData, n.trees=100,type="link")
# Display predicted probabilities
importsTestProbabilities

# PMML generated will be of version v4.2 since, older version(v0.3.0) 'r2pmml' has been loaded. 
r2pmml(imports_GBM ,"Imports.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original imports data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying GBM to entire dataset and save the results in a CSV file
importsEntirePrediction = predict.gbm(imports_GBM, importsOriginal, n.trees=100,type="link")

# Save predicted value in a data frame
result = data.frame(importsEntirePrediction)
names(result) = c("Predicted_price")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)



