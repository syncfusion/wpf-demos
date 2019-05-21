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
# install.packages("nnet")
# install.packages("pmml") 
# install.packages("gmodels") 
# install.packages("rattle") 

# Load below packages
library(nnet)
library(pmml)
library(rattle.data) # This package is specifically loaded for wine dataset shipped within it.
library(gmodels)

# Here we directly load the wine dataset installed with the "rattle" package.
data(wine)

# rename column names for wine dataset from rattle.data package
wineOriginal <- setNames(wine, c("Type", "Alcohol", "Malic_Acid","Ash","Alcalinity","Magnesium","Phenols","Flavanoids","Non_Flavanoids","Proanthocyanins","Color_Intensity","Hue","Dilution","Proline"))

# Omit rows with missing values
wineOriginal <- na.omit(wineOriginal)

# Code below demonstrates loading the same dataset from CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code above to read from CSV file.
# setwd("C:/actual_data_location")
# wine <- read.csv("Wine.csv")

# Considering integer variable as factor
wineOriginal[, "Type"]=as.factor(wineOriginal[, "Type"])

# Randomizing data
wine<- wineOriginal[sample(nrow(wineOriginal)),]

# Divide dataset for training and test
trainData<-wine[1:148,]
testData<-wine[149:178,]

# Applying Neural network model Function with 50 hidden layers
wine_NN<-nnet(Type~.,data=trainData,size=50)
wine_NN

# Displays the predicted results and create cross table to check on accuracy
# Predict "Type" column for test data set
wineTestPrediction<-predict(wine_NN,testData,type="class")
# Display predicted values
wineTestPrediction

# Create cross table to check on accuracy.
CrossTable(testData$Type,wineTestPrediction,prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,
           dnn = c('actual', 'predicted'))

# PMML generation
pmmlFile<-pmml(wine_NN,data=trainData)
write(toString(pmmlFile),file="Wine.pmml")
saveXML(pmmlFile,file="Wine.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original wine data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Neural network model to entire dataset and save the results in a CSV file
wineEntirePrediction<-predict(wine_NN,wineOriginal,type="class")

# Predict probability value for entire dataset
Predicted_probabilities<-predict(wine_NN,wineOriginal)

# Save predicted value and probabilities in a data frame
result = data.frame(wineEntirePrediction,Predicted_probabilities)
names(result) = c("Predicted_Type","FirstClassWineProbability","SecondClassWineProbability","ThirdClassWineProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)