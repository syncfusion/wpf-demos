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
# install.packages("TH.data")
# install.packages("e1071")

# Load below packages
library(pmml)
library(gmodels)
library(TH.data)# This package is specifically loaded for GBSG2 dataset shipped within it.
library(e1071)

# rename column names in GBSG2 dataset from TH.data package
breastCancerOriginal <- setNames(GBSG2, c("Hormonal_Therapy", "Age", "Menopausal_Status", "Tumor_Size", "Tumor_Grade", "Positive_Nodes", 
"Progesterone", "Estrogen_Receptor","Survival_Time", "Indicator"))

# Omit rows with missing values
breastCancerOriginal = na.omit(breastCancerOriginal)

# Convert ordered factor to normal factor
breastCancerOriginal$Tumor_Grade<-factor(breastCancerOriginal$Tumor_Grade, ordered = FALSE)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# breastCancer= read.csv("BreastCancer.csv")

# Randomizing data
breastCancer<-breastCancerOriginal[sample(nrow(breastCancerOriginal)),]

# Divide dataset for training and test
trainData<-breastCancer[1:549,]
testData<-breastCancer[550:686,]

# Applying the General Regression Model - logit function to predict cens
breastCancerFormula = formula(Indicator ~Hormonal_Therapy+Age+Menopausal_Status+Tumor_Size+Tumor_Grade+Positive_Nodes+Progesterone+
Estrogen_Receptor+Survival_Time)
breastCancer_GLM = glm(breastCancerFormula ,trainData, family = binomial(link="logit"))
summary(breastCancer_GLM)

# Display the predicted results 
# Predict "cens" column probability for test data set
breastCancerTestProbabilities = predict(breastCancer_GLM, type = "response",testData)
# Display predicted probabilities 
breastCancerTestProbabilities

# PMML generation
pmmlFile = pmml(breastCancer_GLM,data=trainData)
write(toString(pmmlFile),file="BreastCancer.pmml")
saveXML(pmmlFile,file="BreastCancer.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original breastCancer data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying General Regression model to entire dataset and save the results in a CSV file
breastCancerEntireProbabilities = predict(breastCancer_GLM, type = "response",breastCancerOriginal)

# Save predicted value in a data frame
result = data.frame(breastCancerEntireProbabilities)
names(result) = c("Predicted_censored")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)
