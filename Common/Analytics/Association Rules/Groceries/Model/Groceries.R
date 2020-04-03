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
# install.packages("arules")

# Load below packages
library(pmml)
library(arules)

# Here we directly load the Groceries dataset installed with the "arules" package.
data(Groceries)

#To look at the contents of the sparse matrix, use the inspect() function in combination with vector operators.
inspect(Groceries[1:5])

# Create model for the dataset using apriori
groceriesRules <- apriori(Groceries, parameter = list(support =0.006, confidence = 0.25,minlen = 2))

# PMML generation 
saveXML(pmml(groceriesRules), "Groceries.pmml")
