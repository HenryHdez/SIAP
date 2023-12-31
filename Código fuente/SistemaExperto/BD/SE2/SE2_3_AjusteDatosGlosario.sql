USE [SEMapa]
GO
UPDATE Termino set DefinicionBreve = NombreTermino WHERE DefinicionBreve = '  .'
UPDATE Termino set DefinicionBreve = NombreTermino WHERE DefinicionBreve = '.'
UPDATE Termino set DefinicionBreve = NombreTermino WHERE DefinicionBreve = ''
UPDATE Termino set DefinicionAmplia = 'El riesgo implica la posibilidad de ocurrencia de un daño. En este contexto, un riesgo agroclimático es la probabilidad de que se produzcan pérdidas en la producción agropecuaria, por efecto directo de fenómenos climáticos (déficit hídrico, heladas, etc.). La gestión de riesgo agroclimático es Es un proceso, con enfoque preventivo, que consiste en identificar, evaluar y priorizar los riesgos agroclimáticos; y con ello tomar decisiones para monitorear, reducir o eliminar la probabilidad de ocurrencia de ellos en el predio. Una emergencia agrícola Es una situación de peligro, riesgo o desastre en la producción agropecuaria que requiere de acciones inmediatas. Ejemplos de estas situaciones son nevazones intensas, sequías prolongadas u otros eventos similares que producen daños severos o pérdidas de la producción.' WHERE Codigo='AA13'
UPDATE termino set DefinicionAmplia = 'Amenaza es un fenómeno, sustancia, actividad humana o condición peligrosa que puede ocasionar la muerte, lesiones u otros impactos a la salud, al igual que daños a la propiedad, la pérdida de medios de sustento y de servicios, trastornos sociales y económicos, o daños ambientales. [1] La amenaza se determina en función de la intensidad y la frecuencia.
Vulnerabilidad son las características y las circunstancias de una comunidad, sistema o bien que los hacen susceptibles a los efectos dañinos de una amenaza. (1) Con los factores mencionados se compone la siguiente fórmula de riesgo.
RIESGO = AMENAZA x VULNERABILIDAD (1)
Los factores que componen la vulnerabilidad son la exposición, susceptibilidad y resiliencia, expresando su relación en la siguiente fórmula.
 
VULNERABILIDAD = EXPOSICIÓN x SUSCEPTIBILIDAD / RESILIENCIA (1)

Exposición es la condición de desventaja debido a la ubicación, posición o localización de un sujeto, objeto o sistema expuesto al riesgo.
Susceptibilidad es el grado de fragilidad interna de un sujeto, objeto o sistema para enfrentar una amenaza y recibir un posible impacto debido a la ocurrencia de un evento adverso.
Resiliencia es la capacidad de un sistema, comunidad o sociedad expuestos a una amenaza para resistir, absorber, adaptarse y recuperarse de sus efectos de manera oportuna y eficaz, lo que incluye la preservación y la restauración de sus estructuras y funciones básicas.'
WHERE TerminoId = 5