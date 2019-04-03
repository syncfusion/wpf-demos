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
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("mlbench")
# install.packages("e1071")

# Load below packages
library(pmml)
library(gmodels)
library(mlbench)
library(e1071)

# Here we directly load the ozone dataset installed with the "mlbench" package.
data(Ozone)

# rename column names in Ozone dataset from mlbench package
ozoneOriginal <- setNames(Ozone, c("Month","Day_Of_Month","Day_Of_Week","Ozone_Reading","Pressure","Wind_Speed","Humidity","Sandburg_Temperature",
"ElMonte_Temperature","Inversion_Height","Pressure_Gradient","Inversion_Temperature","Visibility"))

# Omit rows with missing values
ozoneOriginal = na.omit(ozoneOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# ozone= read.csv("Ozone.csv")

# Randomizing data
ozone<- ozoneOriginal[sample(nrow(ozoneOriginal)),]

# Divide dataset for training and test
trainData<-ozone[1:164,]
testData<-ozone[165:203,]

# Applying General Regression Model - sqrt function to predict Average_ozone_reading
ozoneFormula = formula(Ozone_Reading~.)
ozone_GLM = glm(ozoneFormula, trainData, family = quasipoisson(link="sqrt"))
summary(ozone_GLM)

# Display the predicted results and create cross table to check on accuracy
# Predict "average_ozone_reading" column probability for test data set
ozoneTestProbabilities = predict(ozone_GLM,type = "response",testData)
# Display predicted probabilities
ozoneTestProbabilities

# PMML generation
pmmlFile<-pmml(ozone_GLM,data=trainData)
write(toString(pmmlFile),file="Ozone.pmml")
saveXML(pmmlFile,file="Ozone.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original ozone data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying General Regression model to entire dataset and save the results in a CSV file
ozoneEntireProbabilities = predict(ozone_GLM, type = "response",ozoneOriginal)

# Save predicted value in a data frame
result = data.frame(ozoneEntireProbabilities)
names(result) = c("Predicted_AverageOzoneReading")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)








